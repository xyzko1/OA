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
    public class ActionInfoController : BaseController
    {
        // GET: ActionInfo
        public ActionInfoService actionInfoService { get; set; }
        public RoleInfoService roleInfoService { get; set; }

        short delflag = (short)Model.Enum.DelflagEnum.Normal;
        public ActionResult Index()
        {
            return View();
        }
        #region 查询
        public ActionResult GetAllActionInfos()
        {
            //int pageSize = int.Parse(Request["rows"] ?? "10");
            //int pageIndex = int.Parse(Request["page"] ?? "1");
            //int total = 0;

            ////过滤用户名，备注
            //string schName = Request["schName"];
            //string schRemark = Request["schRemark"];

            //short delflagNormal = (short)Model.Enum.DelflagEnum.Normal;
            //var pageData = actionInfoService.GetPageGetEntities(pageSize, pageIndex, out total, u => u.DelFlag == delflagNormal, u => u.ID, true)
            //    .Select(a => new { a.ID, a.IsMenu, a.URL, a.Remark, a.Sort, a.SubTime, a.ModifiedOn, a.HttpMethod, a.MenuIcon, a.ActionName });//导航属性依赖会导致序列化失败
            //var data = new { total = total, rows = pageData.ToList() };

            //return Json(data, JsonRequestBehavior.AllowGet);

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
            var queryParam = new Model.Param.ActionQueryParam()
            {
                SchName = schName,
                SchRemark = schRemark,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Total = total
            };
            var pageData = actionInfoService.GetConditionPageGetData(queryParam).Select(a => new { a.ID, a.IsMenu, a.URL, a.Remark, a.Sort, a.SubTime, a.ModifiedOn, a.HttpMethod, a.MenuIcon, a.ActionName });
            var data = new { total = queryParam.Total, rows = pageData.ToList() };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        public ActionResult Add(ActionInfo actionInfo)
        {
            actionInfo.ModifiedOn = 0;
            actionInfo.SubTime = DateTime.Now;
            actionInfo.DelFlag = delflag;

            actionInfo.IsMenu = Request["IsMenu"] == "true" ? true : false;
            actionInfoService.Add(actionInfo);
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
            actionInfoService.DeleteList(idList);
            return Content("ok");
        }
        #endregion

        #region 修改
        public ActionResult Edit(string id)
        {
            int inid = int.Parse(id);
            ViewData.Model = actionInfoService.GetEntities(u => u.ID == inid).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(ActionInfo actionInfo)
        {
            actionInfoService.Update(actionInfo);
            return Content("ok");
        }
        #endregion
        #region 上传图片
        public ActionResult UploadImage() {
            var file = Request.Files["fileMenuIncon"];
            string path = "/UploadFiles/UploadImgs/" + Guid.NewGuid().ToString() + "-" + file.FileName;
            file.SaveAs(Request.MapPath(path));//相对路径转换为绝对路径

            return Content(".."+path);
        }
        #endregion
        #region 设置角色
        public ActionResult SetRole(string id)
        {
            //if (string.IsNullOrEmpty(id))
            //{
            //    Response.RedirectToRoute("/home/index");
            //}
            int inid = int.Parse(id);
            ActionInfo actionInfo = actionInfoService.GetEntities(u => u.ID == inid).FirstOrDefault();
            ViewData.Model = actionInfo;
            //把所有角色发送到前台
            ViewBag.AllRoles = roleInfoService.GetEntities(u => u.DelFlag == delflag).ToList();

            //用户已关联的角色发送到前台
            ViewBag.ExitRoles = actionInfo.RoleInfo.Select(r => r.ID).ToList();

            return View(actionInfo);
        }
        public ActionResult ProcessSetRole(int UID)
        {
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
            actionInfoService.SetRole(UID, setRoleIDList);
            return Content("ok");
        }
          #endregion
    }
}