using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF.BLL;

namespace WCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //WCF宿主程序

            //using (ServiceHost host=new ServiceHost(typeof(UserInfoService)))//指向具体的服务实现
            //{
            ServiceHost host = new ServiceHost(typeof(UserInfoService));
                host.Open();
                Console.WriteLine("用户服务已启动，按任意键终止");

            ServiceHost Orderhost = new ServiceHost(typeof(OrderInfoService));
            Orderhost.Open();
            Console.WriteLine("订单服务已启动，按任意键终止");

            Console.ReadKey(true);
                host.Close();

            Orderhost.Close();
            //}

        }
    }
}
