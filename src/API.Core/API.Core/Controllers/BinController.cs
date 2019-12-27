using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinController : ControllerBase
    {
        private readonly ILogger<BinController> _logger;
        private readonly IAdvertisementServices advertisementServices;
        public BinController(ILogger<BinController> logger, IAdvertisementServices advertisementServices)
        {
            _logger = logger;
            this.advertisementServices = advertisementServices;
        }

        //public async Task<BinInfoViewModels> GetBinInfo() 
        //{
        //    var model = await advertisementServices.GetBlogDetails(id);

        //    return model;

        //}


    }
}