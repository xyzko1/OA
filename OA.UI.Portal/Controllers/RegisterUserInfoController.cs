using OA.IBLL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.UI.Portal.Controllers
{
    public class RegisterUserInfoController : Controller
    {
        // GET: RegisterUserInfo
        public IUserInfoService UserInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserInfo userInfo)
        {
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            short delflagNormal = (short)Model.Enum.DelflagEnum.Normal;
            var pageData = UserInfoService.GetPageGetEntities(pageSize, pageIndex, out total, u => u.DelFlag == delflagNormal && u.UName == userInfo.UName, u => u.ID, true)
                .Select(u => new { u.ID, u.UName, u.Remark, u.Pwd, u.ShowName, u.SubTime, u.ModifiedOn,u.Email });
            var pageEmailData = UserInfoService.GetPageGetEntities(pageSize, pageIndex, out total, u => u.DelFlag == delflagNormal && u.Email == userInfo.Email, u => u.ID, true)
                .Select(u => new { u.ID, u.UName, u.Remark, u.Pwd, u.ShowName, u.SubTime, u.ModifiedOn, u.Email });
            if(pageData.Count()>0)
            {
                return Content("该用户名已存在!");
            }
            else if (pageEmailData.Count() > 0)
            {
                return Content("该邮箱已被使用!");
            }
            else
            {
                userInfo.ModifiedOn = 0;
                userInfo.SubTime = DateTime.Now;
                userInfo.DelFlag = (short)Model.Enum.DelflagEnum.Normal;
                UserInfoService.Add(userInfo);
                return Content("ok");
            }
        }
    }
}