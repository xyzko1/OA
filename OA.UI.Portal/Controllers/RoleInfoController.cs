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
    public class RoleInfoController : BaseController
    {
        // GET: RoleInfo
        public RoleInfoService roleInfoService { set; get; }
        public ActionResult Index()
        {
            return View();
        }
        #region 查询
        public ActionResult GetAllRoleInfos()
        {

            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;

            //过滤用户名，备注
            string schName = Request["schName"];
            string schRemark = Request["schRemark"];

            //short delflagNormal = (short)Model.Enum.DelflagEnum.Normal;
            //var pageData = RoleInfoService.GetPageGetEntities(pageSize, pageIndex, out total, u => u.DelFlag == delflagNormal, u => u.ID, true)
            //    .Select(u => new { u.ID, u.UName, u.Remark, u.Pwd, u.ShowName, u.SubTime, u.ModifiedOn });//导航属性依赖会导致序列化失败

            ;
            var queryParam = new Model.Param.RoleQueryParam()
            {
                SchName = schName,
                SchRemark = schRemark,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Total = total
            };
            var pageData = roleInfoService.GetConditionPageGetData(queryParam).Select(r => new { r.ID, r.RoleName, r.Remark, r.SubTime, r.ModifiedOn });
            var data = new { total = queryParam.Total, rows = pageData.ToList() };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        public ActionResult Add(RoleInfo RoleInfo)
        {
            RoleInfo.ModifiedOn = 0;
            RoleInfo.SubTime = DateTime.Now;
            RoleInfo.DelFlag = (short)Model.Enum.DelflagEnum.Normal;
            roleInfoService.Add(RoleInfo);
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
            roleInfoService.DeleteList(idList);
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
            ViewData.Model = roleInfoService.GetEntities(u => u.ID == inid).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(RoleInfo RoleInfo)
        {
            roleInfoService.Update(RoleInfo);
            return Content("ok");
        }
        #endregion

    }
}