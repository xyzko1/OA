using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OA.Common
{
    public class LogHelper
    {//观察者模式,memcahe,redis划服务器记录日志
        public delegate void WriteLogDel(string str);//定义委托
        public static Queue<string> ExceptionStringQueue = new Queue<string>();
        //public static WriteLogDel WriteLogDelFunc;
        public static List<ILogWriter> ILogWriterList=new List<ILogWriter>();
        static  LogHelper()//静态构造函数，静态构造函数会在类的静态变量、方法等静态属性时或者在new一个新的对象之前时被调用。
                           //实例构造函数在new一个新的对象时执行
        {
            //WriteLogDelFunc = new WriteLogDel(WriteLogToFile);//通过委托注入添加日志方法
            //WriteLogDelFunc += WriteLogToMongdb;

            ILogWriterList.Add(new TextFileWriter());
            ILogWriterList.Add(new SQLWriter());
            ILogWriterList.Add(new Log4NetWriter());

            //把从队列中获取错误消息写到日志文件
            ThreadPool.QueueUserWorkItem(o =>           //Thread.Start()产生的线程在完成任务后，很快被系统所回收。而ThreadPool（线程池）方式下，线程在完成工作后会被保留一段时间以备resue。所以，当需求需要大量线程并发工作的时候，不建议使用ThreadPool方式，因为它会保持很多额外的线程
            {
                lock (ExceptionStringQueue)
                {
                    string str = ExceptionStringQueue.Dequeue();
                    //把异常信息写到日志文件里
                    //变化点：有可能写到日志文件，有可能写到数据库，有可能两个地方都写，需封装变化点，减少代码改动

                    //执行委托方法，把异常信息写到委托里
                    //WriteLogDelFunc(str);
                    foreach (var LogWriter in ILogWriterList)
                    {
                        LogWriter.WriteLogInfo(str);
                    }

                    //log4net:已经帮我们处理好观察者模式
                }
            });
        }
        public static void WriteLogToFile(string txt) {

        }
        public static void WriteLogToMongdb(string txt)
        {

        }
        public static void WriteLog(string exceptionText) {
            lock (ExceptionStringQueue)
            {
                ExceptionStringQueue.Enqueue(exceptionText);//进入队列
            }
        }
    }
}
