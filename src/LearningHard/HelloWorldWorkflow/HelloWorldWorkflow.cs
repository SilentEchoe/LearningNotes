using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace HelloWorldWorkflow
{
    public class HelloWorldWorkflow: IWorkflow
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


    public class HelloWorld : StepBody
    {
        public override ExecutionResult Run (IStepExecutionContext context)
        {
            Console.WriteLine("Hello world!");
            return ExecutionResult.Next();

        }
    }
    public class ActiveWorld : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("I am activing in the World!");
            return ExecutionResult.Next();
        }
    }
    public class GoodbyeWorld : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Goodbye World!");
            return ExecutionResult.Next();
        }
    }


}
