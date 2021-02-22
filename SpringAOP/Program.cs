using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringAOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //  IUserInfoService userInfoService = new UserInfoService();
            //int result=  userInfoService.Add(3,4);
            //  Console.WriteLine(result);

            //使用spring.net aop代码 
            IApplicationContext ctx = ContextRegistry.GetContext();
            IUserInfoService userInfoService = ctx.GetObject("UserInfoService") as IUserInfoService;

            userInfoService.Add(4,5);

            Console.ReadKey();
        }
    }
}
 