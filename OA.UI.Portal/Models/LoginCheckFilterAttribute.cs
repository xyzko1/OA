using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.UI.Portal.Models
{
    public class LoginCheckFilterAttribute:ActionFilterAttribute
    {
        public bool IsCheckUserLogin { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (IsCheckUserLogin)//设置参数，根据此参数设置页面是否校验
            {
                //校验用户是否已登录
                if (filterContext.HttpContext.Session["loginUser"] == null)
                {
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                }
            }
            
        }
    }
}