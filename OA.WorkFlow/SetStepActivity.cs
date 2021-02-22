using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Spring.Context;
using Spring.Context.Support;
using OA.IBLL;

namespace OA.WorkFlow
{

    public sealed class SetStepActivity : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> StepName { get; set; }
        public InArgument<bool> IsEnd { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            string text = context.GetValue(this.StepName);
            bool end = context.GetValue(this.IsEnd);

            Guid insID = context.WorkflowInstanceId;
            Common.LogHelper.WriteLog("工作流实例ID是：" + context.WorkflowInstanceId);

            IApplicationContext ctx = ContextRegistry.GetContext();
            var wF_instanceService = ctx.GetObject("WF_InstanceService") as IWF_InstanceService;
            var wF_StepService = ctx.GetObject("WF_StepService") as IWF_StepService;
            var inst = wF_instanceService.GetEntities(w=>w.WFInstanceID==insID.ToString()).FirstOrDefault();
            if (inst==null)
            {
                Common.LogHelper.WriteLog("inst is null");
            }

            var stepStatus=Model.Enum.WFStepEnum.UnProcessed.ToString();
            var step = inst.WF_Step.Where(s=>s.StepStatus==stepStatus).FirstOrDefault();
            Common.LogHelper.WriteLog("SetStepActivity:" + text);
            step.StepName = text;
            step.IsEndStep = end;
            if (end)
            {
                step.ProcessResult = "审批结束";
                inst.Status=(short)Model.Enum.WFStepEnum.Processed ;
                wF_instanceService.Update(inst);
            }
            wF_StepService.Update(step);
        }
    }
}
