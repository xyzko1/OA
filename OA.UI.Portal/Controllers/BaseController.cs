using OA.IBLL;
using OA.Model;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.UI.Portal.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public bool IsCheckUserLogin = true;          //通过继承基类实现全局校验
            public UserInfo LoginUser { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (IsCheckUserLogin)//设置参数，根据此参数设置页面是否校验
            {
                //校验用户是否已登录
                if (Request.Cookies["userLoginGuid"] == null)

                //if (filterContext.HttpContext.Session["loginUser"] == null)
                {
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                    return;
                }

                string userGuid = Request.Cookies["userLoginGuid"].Value;
                UserInfo userInfo = Common.Cache.CacheHelper.GetCache(userGuid) as UserInfo;

                if (userInfo==null)
                {
                //用户长时间不操作，超时
                filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                    return;
                }
                LoginUser = userInfo;
                //滑动窗口机制
                Common.Cache.CacheHelper.SetCache(userGuid, userInfo, DateTime.Now.AddMinutes(20));

                //权限校验
                //取当前请求权限数据
                if (LoginUser.UName=="admin")
                {
                    return;
                }
                string url = Request.Url.AbsolutePath;
                string httpMethod = Request.HttpMethod.ToLower();

                //通过容器拿到对象
                IApplicationContext ctx = ContextRegistry.GetContext();

                IActionInfoService actionInfoService = ctx.GetObject("ActionInfoService") as IActionInfoService;

                IR_UserInfo_ActionInfoService r_UserInfo_ActionInfoService = ctx.GetObject("R_UserInfo_ActionInfoService") as IR_UserInfo_ActionInfoService;

                IUserInfoService userInfoService = ctx.GetObject("UserInfoService") as IUserInfoService;

                var actionInfo= actionInfoService.GetEntities(a=>a.URL.ToLower()==url&&a.HttpMethod.ToLower() == httpMethod).FirstOrDefault();

                if (actionInfo==null)
                {
                    Response.Redirect("/Error.html");
                }

                var rUAs = r_UserInfo_ActionInfoService.GetEntities(u=>u.UserInfoID==LoginUser.ID);
                try
                {
                    var item = (from a in rUAs
                                where a.ActionInfoID == actionInfo.ID
                                select a).FirstOrDefault();
                    if (item != null)
                    {
                        if (item.HasPermission == true)
                        {
                            return;
                        }
                        else
                        {
                            Response.Redirect("/Error.html");
                        }
                    }
                    var user = userInfoService.GetEntities(u => u.ID == LoginUser.ID).FirstOrDefault();
                    //取到所有角色
                    var allRoles = from r in user.RoleInfo
                                   select r;
                    //取到所有角色权限
                    var actions = from r in allRoles
                                  from a in r.ActionInfo
                                  select a;
                    //当前角色是否在所有角色全选中
                    var temp = (from a in actions
                                where a.ID == actionInfo.ID
                                select a).Count();

                    if (temp <= 0)
                    {
                        Response.Redirect("/Error.html");
                    }


                }
                catch (Exception)
                {

                }
            }

        }
    }
}