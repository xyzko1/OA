using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;

namespace SpringNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //IUserInfoDal userInfoDal = new UserInfoDal();
            //userInfoDal.Show();

            //走一个容器来创建UserInfoDal

            //初始化容器
            IApplicationContext ctx = ContextRegistry.GetContext();

            //IUserInfoDal userInfoDal = ctx.GetObject("UserInfoDal") as IUserInfoDal;
            //userInfoDal.Show();

            IUserInfoDal efUserInfoDal = ctx.GetObject("EFUserInfoDal") as IUserInfoDal;
            efUserInfoDal.Show();


            //UserInfoService userInfoService = ctx.GetObject("UserInfoService") as UserInfoService;
            //userInfoService.Show();


            Console.ReadKey();
        }
    }
}
