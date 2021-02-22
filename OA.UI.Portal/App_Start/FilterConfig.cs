using OA.UI.Portal.Models;
using System.Web;
using System.Web.Mvc;

namespace OA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //ActionFilter,ResultFilter,异常过滤器 IExceptionFilter
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new MyExceptionFilterAttribute());//注册全局异常过滤器

            //filters.Add(new LoginCheckFilterAttribute() { IsCheckUserLogin = true });
        }
    }
}
