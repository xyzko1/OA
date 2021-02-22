using OA.Common;
using OA.IBLL;
using OA.UI.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.UI.Portal.Controllers
{
    //[LoginCheckFilterAttribute(IsCheckUserLogin = false)]//登录页本身无需校验
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        //IUserInfoService userInfoService = new UserInfoService();
        //
        public IUserInfoService userInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        #region 验证码
        public ActionResult ShowVCode()
        {
            Common.ValidateCode validateCode = new ValidateCode();
            string strCode = validateCode.CreateValidateCode(4);
            //验证码放到Session
            Session["VCode"] = strCode;
            byte[] imgBytes = validateCode.CreateValidateGraphic(strCode);
            return File(imgBytes, @"img/jpeg");
        }
        #endregion

        #region 处理登录表单
        public ActionResult ProcessLogin() {
            #region 处理验证码
            string strCode = Request["VCode"];
            //验证用户名密码
            string sessionCode = Session["VCode"] as string;

            Session["VCode"] = null;//取完之后置为空
          
            if (string.IsNullOrEmpty(sessionCode) || strCode != sessionCode)
            {
                return Content("验证码错误！");
            }
            #endregion
            //处理用户密码
            string name = Request["LoginCode"];
            string pwd = Request["LoginPwd"];

            short delNormal = (short)OA.Model.Enum.DelflagEnum.Normal;
          var userinfo=userInfoService.GetEntities(u=>u.UName==name&&u.Pwd==pwd&&u.DelFlag== delNormal)
                .FirstOrDefault();
            //如果正确跳转到首页
            if (userinfo==null)
            {
                return Content("用户密码错误！");
            }
            //Session["loginUser"] = userinfo;
            //memcache+cookie
            //分配一个guid作为mm存储数据的key，把用户对象放入，guid存入客户端缓存
            string userLoginGuid = Guid.NewGuid().ToString();
            //用户数据写入mm
            Common.Cache.CacheHelper.AddCache(userLoginGuid, userinfo, DateTime.Now.AddMinutes(20));
            //往客户端写入Cookie
            Response.Cookies["userLoginGuid"].Value = userLoginGuid;//未设置时间未会话级别Cookie

            //如果正确那么跳转到首页
            return Content("ok");
        }
        #endregion
    }
}