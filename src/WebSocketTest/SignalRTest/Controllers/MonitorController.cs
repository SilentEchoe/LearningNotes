using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRTest.Hubs;

namespace SignalRTest.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class MonitorController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public MonitorController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        /// <summary>
        /// SignalR send data
        /// </summary>
        /// <returns></returns>
        // GET: api/Logs
        [HttpGet]
        public MessageModel<List<LogInfo>> Get()
        {

            LogInfo logInfo = new LogInfo()
            {
                Content = "IP:127.0.0.1<br>/api/monitor/get",
                Datetime = DateTime.Now,
                IP = "127.1.1.1",
                Import = 0,
                LogColor = "ReqRes"


            };
            List<LogInfo> logInfos = new List<LogInfo>();
            logInfos.Add(logInfo);
            _hubContext.Clients.All.SendAsync("ReceiveUpdate", logInfos).Wait();

            return new MessageModel<List<LogInfo>>()
            {
                msg = "获取成功",
                success = true,
                response = null
            };
        }


    }

    public class LogInfo
    {
        public DateTime Datetime { get; set; }
        public string Content { get; set; }
        public string IP { get; set; }
        public string LogColor { get; set; }
        public int Import { get; set; } = 0;
    }

}