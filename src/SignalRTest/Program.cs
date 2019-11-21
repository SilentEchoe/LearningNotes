using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace SignalRTest
{
    class Program
    {

        private IDisposable _hub;
        private IHubContext _hubContext;

       
        static void Main(string[] args)
        {

            _hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            Console.WriteLine("Hello World!");


        }
    }
}
