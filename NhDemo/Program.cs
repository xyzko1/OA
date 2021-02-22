using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhDemo
    //NH开源 不依赖.NetFrameWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //通过配置文件创建Nh
            //var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");  
            var cfg = new NHibernate.Cfg.Configuration().Configure();
            ISessionFactory  sessionFactory = cfg.BuildSessionFactory();

            //通过工厂创建一个Session对象
            var session = sessionFactory.OpenSession();//相当于EF上下文

            //var trans = session.BeginTransaction();//启动事物,查询无需事物

            //操作数据库实体
            //stuinfo stuinfoModel = new stuinfo();
            //stuinfoModel.Name = "NH";
            //stuinfoModel.Native = "HuBei";
            //stuinfoModel.Gender = "男";
            //stuinfoModel.Age = 18;

            //session.Save(stuinfoModel);//添加操作
            //session.SaveOrUpdate(stuinfoModel);//添加操作

            //session.Delete(new stuinfo() { No=0});//删除操作

            var temp = from u in session.Query<stuinfo>()
                        where u.No < 10
                        select u;
            foreach (var item in temp)
            {
                Console.WriteLine(item.Name+"\n");
            }
            
            //trans.Commit();
            session.Close();
            Console.ReadKey();





        }
    }
}
