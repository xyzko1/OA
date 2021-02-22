using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4NetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();//读取配置初始化

            //写日志
            ILog logWriter = log4net.LogManager.GetLogger("DemoWritter");
            logWriter.Debug("debug");
            logWriter.Error("error");
        }
    }
}
