using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace OA.WorkFlow
{

    public sealed class Wait4InputActivity<T> : NativeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> InBookMarkName { get; set; }
        public OutArgument<T> OutPutData { get; set; }
        protected override bool CanInduceIdle {
            get { return true; }
        }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。

        protected override void Execute(NativeActivityContext context)
        {
            //获取Text输入参数的运行时值
            string text = context.GetValue(this.InBookMarkName);
            context.CreateBookmark(text, new BookmarkCallback(MethodCallBack));
        }

        private void MethodCallBack(NativeActivityContext context, Bookmark bookmark, object value)
        {
            context.SetValue(OutPutData,(T) value);
        }
    }
}
