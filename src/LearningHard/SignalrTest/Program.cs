using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;

namespace SignalrTest
{
    class Program
    {

        private static IHubContext _hubContext;
        private static IDisposable _hub;
        static void Main(string[] args)
        {
           _hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

            _hub = HubServer.InitialHubServer();

        }
        void Send(string name, string msg)
        {
            _hubContext.Clients.All.addMessage(name, msg);
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
                _signalR = WebApp.Start("http://localhost:56789");
            }
            catch (TargetInvocationException ex)
            {
                string a = ex.ToString();
            }

            return _signalR;
        }
    }


    /// <summary>
    /// Used by OWIN's startup process.
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }


    public class MyHub : Hub
    {
      
        public void Send(string name, string message)
        {
            switch (name)
            {
               

                default:
                    {
                        this.Clients.Client(this.Context.ConnectionId).addMessage(name, this.Context.ConnectionId);
                        break;
                    }
            }
        }

        // 通讯连接
        public override Task OnConnected()
        {
            this.SendStatus();
            var c_connected = base.OnConnected();
            return c_connected;
        }

        private void SendStatus()
        {
            this.Clients.Client(this.Context.ConnectionId)
                .addMessage("1","");
            
        }

    

        public override Task OnReconnected()
        {
            this.SendStatus();
            return base.OnReconnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
          
            return base.OnDisconnected(stopCalled);
        }

      
    }

}
