using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;

namespace HelloWorldWorkflow
{
    public class Workflow: IWorkflow
    {
        public string Id => "HelloWorld";

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder )
        {
            builder.StartWith<HelloWorld>()
                .Then<ActiveWorld>()
                .Then<GoodbyeWorld>();


        }

    }


    public class HelloWorld : IStepBody
    {

    }


}
