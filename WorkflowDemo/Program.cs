using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace WorkflowDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            //Activity workflow1 = new Workflow1();
            Activity workflow1 = new LeaveActivity();

            WorkflowInvoker.Invoke(workflow1);
            Console.ReadKey();
        }
    }
}
