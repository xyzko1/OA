using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OA.WorkFlow
{
   public class WorkflowApplicationHelper
    {
        private static readonly string StrSql;
        static WorkflowApplicationHelper() {
            StrSql = ConfigurationManager.ConnectionStrings["wfsql"].ConnectionString;
        }

        public static WorkflowApplication CreateWorkflowApp(Activity activity, Dictionary<string, object> dicParam) {
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            WorkflowApplication wfApp;
            if (dicParam == null)
            {
                wfApp = new WorkflowApplication(activity);
            }
            else
            {
                wfApp = new WorkflowApplication(activity, dicParam);
            }

            wfApp.Idle += a =>//当工作流停下来时，执行此事件响应方法
            {
                Console.WriteLine("工作流停下来了");
                Common.LogHelper.WriteLog("工作流停下来了");
            };

            //当咱们工作流停顿下来的时候，进行什么操作。如果返回是Unload。那么就卸载当前
            //工作流实例，持久化到数据库里去
            wfApp.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs e2)
            {
                Console.WriteLine("工作流卸载进行持久化，书签被创建时候就会执行序列化到数据库里面");
                Common.LogHelper.WriteLog("工作流卸载进行持久化");
                return PersistableIdleAction.Unload;
            };
            wfApp.Unloaded += a =>
            {
                autoResetEvent.Set();
                Console.WriteLine("工作流被卸载");
                Common.LogHelper.WriteLog("工作流被卸载");
            };
            wfApp.OnUnhandledException += a =>
            {
                autoResetEvent.Set();
                Console.WriteLine("出现了异常");
                Common.LogHelper.WriteLog(a.UnhandledException.ToString());
                return UnhandledExceptionAction.Terminate;//当出现未处理异常的时候，直接结束工作流
            };
            wfApp.Aborted += a =>
            {
                autoResetEvent.Set();
                Console.WriteLine("Aborted");
                Common.LogHelper.WriteLog("Aborted");
            };

            //创建一个保存 工作流实例的sqlstore对象

            SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(StrSql);

            //wfApp在进行持久化的时候，保存到上面对象配置的数据库里

            wfApp.InstanceStore= store;
            wfApp.Run();
            return wfApp;
        }

        public static WorkflowApplication ResumeBookMark(Activity activity,Guid instanceID,string bookmarkName,object value) {
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            WorkflowApplication wfApp = new WorkflowApplication(activity);
            wfApp.Idle += a =>//当工作流停下来的时候，执行此事件响应方法
            {
                Console.WriteLine("工作流停下来");
            };
            //当咱们工作流停顿下来的时候，进行什么操作。如果返回是Unload。那么就卸载当前
            //工作流实例，持久化到数据库里去
            wfApp.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs e3)
            {
                Console.WriteLine("工作流卸载进行持久化，书签被创建时候就会执行序列化到数据库里面");
                Common.LogHelper.WriteLog("工作流卸载进行持久化");
                return PersistableIdleAction.Unload;
            };
            wfApp.Unloaded += a =>
            {
                autoResetEvent.Set();
                Console.WriteLine("工作流被卸载");
                Common.LogHelper.WriteLog("工作流被卸载");
            };
            wfApp.OnUnhandledException += a =>
            {
                autoResetEvent.Set();
                Console.WriteLine("出现了异常");
                Common.LogHelper.WriteLog(a.UnhandledException.ToString());
                return UnhandledExceptionAction.Terminate;//当出现未处理异常的时候，直接结束工作流
            };
            wfApp.Aborted += a =>
            {
                autoResetEvent.Set();
                Console.WriteLine("Aborted");
                Common.LogHelper.WriteLog("Aborted");
            };


            //创建一个保存 工作流实例的sqlstore对象

            SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(StrSql);

            //wfApp在进行持久化的时候，保存到上面对象配置的数据库里

            wfApp.InstanceStore = store;

            //从数据库加载当前工作流实例的状态
            wfApp.Load(instanceID);

            //让工作流沿着Demo书签继续往下执行
            wfApp.ResumeBookmark(bookmarkName,value);

            return wfApp;
        }
    }
}
