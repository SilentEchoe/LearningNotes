using System;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

namespace HelloWorldWorkflow
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var serviceProvider = ConfigureServices();
            var host = serviceProvider.GetService<IWorkflowHost>();
           
            //host.RegisterWorkflow<HelloWorldWorkflow>();
            host.RegisterWorkflow<IfStatementWorkflow, MyData>();

            host.Start();

            // Demo1:Hello World

            string workflowId = host.StartWorkflow("if-sample", new MyData() { Counter = 4 }).Result;

            //host.StartWorkflow("HelloWorld");

            Console.ReadKey();
            host.Stop();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging(); // WorkflowCore需要用到logging service
            services.AddWorkflow();

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }

  

}
}
