using Microsoft.AspNetCore.SignalR;
using System;
using System.Reflection;
using System.Threading.Tasks;
namespace SignalRTest
{
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
        public static bool IsExecute = true;
      
        public void Send(string name, string message)
        {
            switch (name)
            {
                
                case "":
                    {
                     
                        Clients.Client(Context.ConnectionId).SendAsync(name);
                        //Clients.Client(Context.ConnectionId).addMessage(name, "1");
                        break;
                    }


                default:
                    {
                        Clients.Client(Context.ConnectionId).SendAsync(name);
                        //Clients.Client(Context.ConnectionId).addMessage(name, Context.ConnectionId);
                        break;
                    }
            }
        }




     

        // 重连
        public override Task OnReconnected()
        {
           
            return base.OnReconnected();
        }

        // 连接
        public override Task OnConnected()
        {
            
            var cConnected = base.OnConnected();
            return cConnected;
        }


       


    }


}