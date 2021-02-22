﻿using AopAlliance.Intercept;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringAOP
{
   public class ConsoleLoggingAroundAdvice:IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            Console.Out.WriteLine("Advice executing;calling the advised method...");
            object returnValue = invocation.Proceed();
            Console.Out.WriteLine("Advice executed;advised method return "+ returnValue);
            return returnValue;
        }
    }
}
