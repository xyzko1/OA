using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.UI.Portal.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            //if (Session["loginUser"]==null)
            //{
            //    return RedirectToAction("index","UserLogin");
            //}
            if (LoginUser!=null)
            {
                ViewData["UName"] = LoginUser.UName;
            }
            return View();
        }
        public ActionResult logout() {
            //Common.Cache.CacheHelper.SetCache(Request.Cookies["userLoginGuid"].Value, null, DateTime.Now.AddMinutes(20));
            return RedirectToAction("index", "UserLogin");
        }
    }
}