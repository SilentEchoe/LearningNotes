using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core.IServices;
using API.Core.Model.Models;
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
        /// <param name="id">第一个变量</param>  
        /// <returns></returns>
        [HttpGet]
        public async Task<List<BinInfo>> GetAsync(int id)
        {
            IAdvertisementServices advertisementServices = new AdvertisementServices();

            return await advertisementServices.Query(d => d.Id == id);


            //IAdvertisementServices advertisementServices = new AdvertisementServices();
            //return advertisementServices.Sum(i, j);
        }
    }
}
