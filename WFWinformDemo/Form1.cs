using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFWinformDemo
{
    
    public partial class Form1 : Form
    {
        private WorkflowApplication workflowApplication;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //WorkflowInvoker.Invoke(new DemoActivity(),new Dictionary<string, object>() {
            //    { "BookMarkName",this.txtBookMarkName.Text}
            //});

             workflowApplication = new WorkflowApplication(new DemoActivity(), new Dictionary<string, object>()
            {
                 { "BookMarkName",this.txtBookMarkName.Text}
                });

            workflowApplication.Idle += AfterWorkflowIdel;
            workflowApplication.OnUnhandledException += OnWfAppException;

            workflowApplication.Unloaded = a => { Console.WriteLine("工作流卸载"); };
            workflowApplication.Aborted = a => { Console.WriteLine("Aborted"); };
            workflowApplication.Run();
            }
        //工作流空闲时执行此方法（创建书签时）
        private void AfterWorkflowIdel(WorkflowApplicationIdleEventArgs obj)
        {
            Console.WriteLine("工作流停下来了");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            workflowApplication.ResumeBookmark(txtBookMarkName.Text,int.Parse(txtMoney.Text));//继续书签
        }
        private UnhandledExceptionAction OnWfAppException(WorkflowApplicationUnhandledExceptionEventArgs arg) {

            Console.WriteLine("未处理的异常"+arg.UnhandledException.ToString());
            return UnhandledExceptionAction.Terminate;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            workflowApplication = new WorkflowApplication(new StateActivity());

            workflowApplication.Run();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            workflowApplication = new WorkflowApplication(new StateMoneyActivity(), new Dictionary<string, object>()
            {
                 { "BookMarkName",this.txtBookMarkName.Text}
                });

            workflowApplication.Run();
        }
    }
}
