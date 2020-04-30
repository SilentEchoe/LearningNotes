using Grpc.Net.Client;
using GrpcServer.Web.Protos;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
           using var channel = GrpcChannel.ForAddress("https://localhost:5001");
           var client = new EmployeeService.EmployeeServiceClient(channel);

            var response = await client.GetByNoAsync(new GetByNoRequest
            {
                No = 1994
            });

            Console.WriteLine($"Response messages :{ response }");
            Console.WriteLine("press any key to exit.");
            Console.ReadKey();
            
        }
    }
}
