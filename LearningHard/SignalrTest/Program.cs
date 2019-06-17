using System;
using System.Reflection;

namespace SignalrTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public static class HubServer
    {
        private static IDisposable _signalR;

        public static IDisposable InitialHubServer()
        {
            if (_signalR != null)
            {
                return _signalR;
            }

            try
            {
                //_signalR = WebApp.Start(HubConfiguration.URL);
            }
            catch (TargetInvocationException ex)
            {
                string a = ex.ToString();
            }

            return _signalR;
        }
    }



}
