using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace Signalr
{
    public static class HubConfiguration
    {
        public const string URL = "http://localhost:56789";

    }


    public class MyHub 
    {
       

        private delegate void DoTask();

        public void Send(string name, string message)
        {
          

            switch (name)
            {
            }
        }

        // 通讯连接
        //public override Task OnConnected()
        //{
        //    this.SendStatus();
        //    var c_connected = base.OnConnected();
        //    return c_connected;
        //}


      



    

      


      
    }

}
