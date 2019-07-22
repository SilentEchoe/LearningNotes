using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace HelloWorldWorkflow
{
    public class IfStatementWorkflow: IWorkflow<MyData>
    {
        public string Id => "if-sample";

        public int Version => 1;

        public void Build(IWorkflowBuilder<MyData> builder)
        {
            builder.StartWith<SayHello>()
              .If(data => data.Counter < 3).Do(then => then
                       .StartWith<PrintMessage>()
                           .Input(step => step.Message, data => "Outcome is less than 3")
               ).If(data => data.Counter < 5).Do(then => then
                       .StartWith<PrintMessage>()
                           .Input(step => step.Message, data => "Outcome is less than 5")
               )
               .Then<SayHello>();
        }
    }


    public class MyData
    {
        public int Counter { get; set; }
    }

    public class SayHello : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Hello world!");
            return ExecutionResult.Next();

        }
    }

    public class PrintMessage : StepBody
    {
        public string Message { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine(Message);
            return ExecutionResult.Next();
        }
    }



}
