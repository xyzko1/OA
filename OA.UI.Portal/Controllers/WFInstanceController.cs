using OA.BLL;
using OA.IBLL;
using OA.Model;
using OA.WorkFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.UI.Portal.Controllers
{
    public class WFInstanceController : BaseController
    {
        // GET: WFInstance
        short delflagNormal = (short)Model.Enum.DelflagEnum.Normal;
        public WF_TempService wF_TempService { get; set; }
        public WF_InstanceService wF_InstanceService { get; set; }
        public  WF_StepService wF_StepService { get; set; }
        public UserInfoService UserInfoService { get; set; }
        public ActionResult Index()
        {
            var TempData = wF_TempService.GetEntities(u => u.DelFlag==delflagNormal).ToList();
            ViewData.Model = TempData;
            return View();
        }
        //发起流程:流程模板的id
        public ActionResult Add(int id)
        {
          var TempData=wF_TempService.GetEntities(u=>u.ID==id).FirstOrDefault();
            ViewBag.Temp = TempData;
            

          var allUsers=UserInfoService.GetEntities(u=>u.DelFlag==delflagNormal).ToList();
            ViewData["UserList"] = (from u in allUsers
                                    select new SelectListItem() { Selected = false, Text = u.UName, Value = u.ID+"" }).ToList(); ;

            return View();
        }
        //发起流程
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(WF_Instance instance,int id,int flowTo)
        {

            var currentUserID = LoginUser.ID;
            //工作流实例表添加数据

            instance.DelFlag = delflagNormal;
            instance.StartTime = DateTime.Now;
            //instance.FilfieInfo = string.Empty;

            instance.StartBy = currentUserID.ToString();
            instance.Level = 0;
            //instance.Status = (short)Model.Enum.WF_InstanceEnum.Processing;
            instance.WFInstanceID = Guid.Empty.ToString();
            instance.WF_TempID = id;
            wF_InstanceService.Add(instance);

            //启动工作流
            var wfApp = WorkflowApplicationHelper.CreateWorkflowApp(new FincalActivity(),null);
            instance.WFInstanceID = wfApp.Id.ToString();
            wF_InstanceService.Update(instance);

            //在步骤表中添加两条步骤，一个当前已处理的完成步骤
            WF_Step startStep = new WF_Step();
            startStep.WF_InstanceID = instance.ID;
            startStep.SubTime = DateTime.Now;
            startStep.ProcessTime = DateTime.Now;
            startStep.ProcessComment = "提交申请";

            startStep.IsStartStep = true;
            startStep.IsEndStep = false;
            startStep.ProcessBy = currentUserID.ToString();
            startStep.StepName = "提交审批表单";
            startStep.ProcessResult = "通过";
            startStep.StepStatus =Model.Enum.WFStepEnum.Processed.ToString();

            wF_StepService.Add(startStep);

            //下一步审核步骤，项目经理审批

            WF_Step nextStep = new WF_Step();
            nextStep.WF_InstanceID = instance.ID;
            nextStep.SubTime = DateTime.Now;
            nextStep.ProcessTime = DateTime.Now;
            nextStep.ProcessComment = "";

            nextStep.IsStartStep = false;
            nextStep.IsEndStep = false;
            nextStep.ProcessBy = flowTo.ToString();
            nextStep.ProcessResult = "";
            nextStep.StepStatus= Model.Enum.WFStepEnum.UnProcessed.ToString();
            wF_StepService.Add(nextStep);

            return RedirectToAction("ShowMyCheck");
        }
        //显示待审批流程
        public ActionResult ShowMyUnCheck() {

            var runEnum = Model.Enum.WFStepEnum.UnProcessed.ToString();
            var instanceEnum = (short)Model.Enum.WFStepEnum.Processing;
            string strLoginUserID = LoginUser.ID.ToString();
            var steps = wF_StepService.GetEntities(s => s.StepStatus == runEnum && s.ProcessBy == strLoginUserID).ToList() ;

            var instanceIDs = (from s in steps select s.WF_InstanceID).Distinct();

            var data = wF_InstanceService.GetEntities(i => instanceIDs.Contains(i.ID) && i.Status == instanceEnum).ToList();

            return View(data);
        }

        //显示审批流程
        public ActionResult ShowMyCheck()
        {

            var runEnum = Model.Enum.WFStepEnum.UnProcessed.ToString();
            var instanceEnum = (short)Model.Enum.WFStepEnum.Processed;
            string strLoginUserID = LoginUser.ID.ToString();
            var steps = wF_StepService.GetEntities(s => s.StepStatus == runEnum && s.ProcessBy == strLoginUserID).ToList();

            var instanceIDs = (from s in steps select s.WF_InstanceID).Distinct();

            var data = wF_InstanceService.GetEntities(i => instanceIDs.Contains(i.ID) && i.Status == instanceEnum).ToList();

            return View(data);
        }

        #region 审批
        public ActionResult ShowCheck(int id) {
            ViewData.Model = wF_InstanceService.GetEntities(u=>u.ID==id).FirstOrDefault();
            ViewData["flowTo"] = UserInfoService.GetEntities(u => u.DelFlag == delflagNormal).ToList().Select(u => new SelectListItem() { Selected = false, Text = u.UName, Value = u.ID.ToString() });

            return View();
        }
      /// <summary>
      /// 审批
      /// </summary>
      /// <param name="stepID">当前步骤id</param>
      /// <param name="isPass"></param>
      /// <param name="Comment"></param>
      /// <param name="flowTo"></param>
      /// <returns></returns>
        public ActionResult DoCheck(int stepID,bool isPass,string Comment,int flowTo) {
            //更新当前步骤
            var step = wF_StepService.GetEntities(s=>s.ID==stepID).FirstOrDefault();
            step.ProcessResult = isPass ? "通过" : "不通过";
            step.StepStatus = Model.Enum.WFStepEnum.Processed.ToString();
            step.ProcessTime = DateTime.Now;

            step.ProcessComment = Comment;
            wF_StepService.Update(step);

            //初始化下一个步骤
            var nextstep = wF_StepService.GetEntities(s => s.ID == stepID).FirstOrDefault();
            nextstep.IsEndStep = false;
            nextstep.IsStartStep = false;
            nextstep.ProcessBy = flowTo.ToString();
            nextstep.SubTime = DateTime.Now;
            nextstep.ProcessResult = "";
            nextstep.StepStatus = Model.Enum.WFStepEnum.UnProcessed.ToString();
            nextstep.StepName = "";
            nextstep.WF_InstanceID = step.WF_InstanceID;
            nextstep.ProcessTime = DateTime.Now;
            nextstep.ProcessComment = "";

            wF_StepService.Add(nextstep);

            //让书签继续往下执行
            var Value = isPass ? 1 : 0;

            WorkFlow.WorkflowApplicationHelper.ResumeBookMark(new FincalActivity(),new Guid(step.WF_Instance.WFInstanceID),step.StepName,Value);
            return Content("ok");
        }
        #endregion
    }
}