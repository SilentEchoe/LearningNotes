using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core.IServices;
using API.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Core.Controllers
{
    [Produces("application/json")]
    [Route("api/WeatherForecast")]
   
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

      /// <summary>
      /// 测试例子
      /// </summary>
      /// <param name="i">第一个变量</param>
      /// <param name="j">第二个变量</param>
      /// <returns></returns>
        [HttpGet]
        public int Get(int i,int j)
        {
            IAdvertisementServices advertisementServices = new AdvertisementServices();
            return advertisementServices.Sum(i, j);
        }
    }
}
