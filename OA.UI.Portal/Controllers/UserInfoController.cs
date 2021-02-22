using OA.BLL;
using OA.IBLL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.UI.Portal.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        //IUserInfoService userInfoService = new UserInfoService();
        public IUserInfoService userInfoService { get; set; }
        public IRoleInfoService roleInfoService { get; set;  }

        public IActionInfoService actionInfoService { get; set; }

        public IR_UserInfo_ActionInfoService r_UserInfo_ActionInfoService { get; set; }

        short delflag= (short) Model.Enum.DelflagEnum.Normal;

        public ActionResult Index()
        {
            ViewData.Model= userInfoService.GetEntities(u => true);
            return View();
        }
        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                userInfoService.Add(userInfo);
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region 查询
        public ActionResult GetAllUserInfos()
        {

            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;

            //过滤用户名，备注
            string schName = Request["schName"];
            string schRemark = Request["schRemark"];

            //short delflagNormal = (short)Model.Enum.DelflagEnum.Normal;
            //var pageData = userInfoService.GetPageGetEntities(pageSize, pageIndex, out total, u => u.DelFlag == delflagNormal, u => u.ID, true)
            //    .Select(u => new { u.ID, u.UName, u.Remark, u.Pwd, u.ShowName, u.SubTime, u.ModifiedOn });//导航属性依赖会导致序列化失败

           ;
            var queryParam = new Model.Param.UserQueryParam()
            {
                SchName = schName,
                SchRemark = schRemark,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Total = total
            };
            var pageData = userInfoService.GetConditionPageGetData(queryParam).Select(u => new { u.ID, u.UName, u.Remark, u.Pwd, u.ShowName, u.SubTime, u.ModifiedOn });
            var data = new { total = queryParam.Total, rows = pageData.ToList() };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        public ActionResult Add(UserInfo userInfo)
        {
            userInfo.ModifiedOn = 0;
            userInfo.SubTime = DateTime.Now;
            userInfo.DelFlag = delflag;
            userInfoService.Add(userInfo);
            return Content("ok");
        }
        #endregion
        #region 删除
        public ActionResult Delete(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return Content("请选中要删除的数据！");
            }
            string[] strids = ids.Split(',');
            List<int> idList = new List<int>();
            foreach (var strid in strids)
            {
                idList.Add(int.Parse(strid));
            }
            userInfoService.DeleteList(idList);
            return Content("ok");
        }
        #endregion

        #region 修改
        public ActionResult Edit(string id)
        {
            //if (string.IsNullOrEmpty(id))
            //{
            //    Response.RedirectToRoute("/home/index");
            //}
            int inid = int.Parse(id);
            ViewData.Model = userInfoService.GetEntities(u=>u.ID== inid).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(UserInfo userInfo)
        {
            userInfoService.Update(userInfo);
            return Content("ok");
        }
        #endregion
        #region 设置角色
        public ActionResult SetRole(int id)
        {
            //if (string.IsNullOrEmpty(id))
            //{
            //    Response.RedirectToRoute("/home/index");
            //}
            //int inid = int.Parse(id);
            UserInfo userInfo = userInfoService.GetEntities(u => u.ID == id).FirstOrDefault();
            ViewData.Model = userInfo;
            //把所有角色发送到前台
            ViewBag.AllRoles =roleInfoService.GetEntities(u => u.DelFlag == delflag).ToList();

            //用户已关联的角色发送到前台
            ViewBag.ExitRoles = userInfo.RoleInfo.Select(r=>r.ID).ToList();

            return View(userInfo);
        }
        //设置用户角色
        public ActionResult ProcessSetRole(int UID) {
            //当前用户ID,所有被勾选角色
            List<int> setRoleIDList = new List<int>();
            foreach (var key in Request.Form.AllKeys)//遍历表单中所有的Key
            {
                if (key.StartsWith("ckb_"))
                {
                    int roleID = int.Parse(key.Replace("ckb_", ""));
                    setRoleIDList.Add(roleID);
                }
            }
            userInfoService.SetRole(UID, setRoleIDList);
            return Content("ok");
        }
        #endregion

        #region 设置特殊权限
        public ActionResult SetAction(int id)
        {
            //if (string.IsNullOrEmpty(id))
            //{
            //    Response.RedirectToRoute("/home/index");
            //}
            //int inid = int.Parse(id);
            UserInfo userInfo = userInfoService.GetEntities(u => u.ID == id).FirstOrDefault();
            ViewBag.UserInfo = userInfo;
            //把所有角色发送到前台
            List<ActionInfo> actionInfos = actionInfoService.GetEntities(u => u.DelFlag == delflag).ToList();
            ViewData.Model = actionInfos;
            Dictionary<int, string> dic = new Dictionary<int, string>();
            foreach (var item in actionInfos)
            {
                var rUserAction = r_UserInfo_ActionInfoService.GetEntities(r => r.UserInfoID == userInfo.ID && r.ActionInfoID == item.ID && r.DelFlag == delflag).FirstOrDefault();
                if (rUserAction!=null)
                {
                    dic.Add(item.ID, rUserAction.HasPermission ? "1" : "0");
                }
            }
            ViewBag.RadioState = dic;
            //用户已关联的角色发送到前台
            ViewBag.ExitRoles = userInfo.RoleInfo.Select(r => r.ID).ToList();
           
            return View();
        }
        //设置特殊权限
        public ActionResult ProcessSetAction(int UID)
        {
            //当前用户ID,所有被勾选角色
            List<int> setActionIDList = new List<int>();
            foreach (var key in Request.Form.AllKeys)//遍历表单中所有的Key
            {
                if (key.StartsWith("ckb_"))
                {
                    int roleID = int.Parse(key.Replace("ckb_", ""));
                    setActionIDList.Add(roleID);
                }
            }
            userInfoService.SetAction(UID, setActionIDList);
            return Content("ok");
        }
        public ActionResult DeleteUserAction(int UID,int ActionID)
        {
            var rUserAction = r_UserInfo_ActionInfoService.GetEntities(r => r.UserInfoID == UID && r.ActionInfoID == ActionID ).FirstOrDefault();
            if (rUserAction!=null)
            {
                r_UserInfo_ActionInfoService.DeleteList(new List<int>() { rUserAction.ID});
            }
             
                return Content("ok");
        }
        public ActionResult SetUserAction(int UID, int ActionID,string Value)
        {
            var rUserAction = r_UserInfo_ActionInfoService.GetEntities(r => r.UserInfoID == UID && r.ActionInfoID == ActionID&&r.DelFlag==delflag).FirstOrDefault();
            if (rUserAction != null)
            {
                rUserAction.HasPermission = Value == "1"? true : false;
                rUserAction.SubTime = DateTime.Now;
                rUserAction.ModifiedOn = 1;
                r_UserInfo_ActionInfoService.Update(rUserAction);
            }
            else
            {
                R_UserInfo_ActionInfo rUserInfoActionInfo = new R_UserInfo_ActionInfo();
                rUserInfoActionInfo.ActionInfoID = ActionID;
                rUserInfoActionInfo.UserInfoID = UID;
                rUserInfoActionInfo.SubTime = DateTime.Now;
                rUserInfoActionInfo.HasPermission = Value == "1" ? true : false;
                rUserInfoActionInfo.DelFlag = delflag;
                rUserInfoActionInfo.ModifiedOn = 0;
                r_UserInfo_ActionInfoService.Add(rUserInfoActionInfo);
            }

            return Content("ok");
        }
        #endregion

    }
}