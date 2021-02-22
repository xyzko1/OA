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
    public class WFTempController : Controller
    {
        // GET: WFTemp
        public WF_TempService wF_TempService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        #region 查询
        public ActionResult GetAllTempInfos()
        {

            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;

            //过滤用户名，备注
            string schName = Request["schName"];
            string schRemark = Request["schRemark"];

            
            var queryParam = new Model.Param.TempQueryParam()
            {
                SchName = schName,
                SchRemark = schRemark,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Total = total
            };
            var pageData = wF_TempService.GetConditionPageGetData(queryParam).Select(r => new { r.ID, r.TempName, r.Remark, r.SubTime, r.ActivityType });
            var data = new { total = queryParam.Total, rows = pageData.ToList() };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        //显示添加页面
        public ActionResult Add() {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]//非法字符
        public ActionResult Add(WF_Temp temp)
        {
            temp.DelFlag = (short)Model.Enum.DelflagEnum.Normal;
            temp.SubTime = DateTime.Now;
            wF_TempService.Add(temp);
            return Content("ok");
        }
        #endregion

    }
}