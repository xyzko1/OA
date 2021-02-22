using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WFWinformDemo
{
    //1、让工作流停下来
    //2、把用户通过Winform输入的信息传到工作流中
    //public sealed class InputMoneyActivity : CodeActivity
    public sealed class InputMoneyActivity : NativeActivity  //改为NativeActivity创建书签
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> InBookMarkName { get; set; }
        public OutArgument<int> OutMoney { get; set; }
        //public InOutArgument<string> InOutArgument { get; set; }

        protected override bool CanInduceIdle {
            get { return true; }
        }    

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        //protected override void Execute(NativeActivity context)
        //{
        // 获取 Text 输入参数的运行时值
        //string text = context.GetValue(this.Text);

        //int money = int.Parse(Console.ReadLine());
        //context.SetValue(OutMoney, money);
        //}

        protected override void Execute(NativeActivityContext context)
        {
            //1、让工作流停下来
            //2、有数据库，让工作流继续往下流动

            string bookMarkName = context.GetValue(InBookMarkName);

            Console.WriteLine("创建书签");
            //3、创建书签
            context.CreateBookmark(bookMarkName,new BookmarkCallback(CallBackFun));
        }

        //继续书签时执行的代码
        private void CallBackFun(NativeActivityContext context, Bookmark bookmark, object value)
        {
            context.SetValue(OutMoney,(int)value);
            Console.WriteLine("书签继续执行。。。");
        }
    }
}
