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
    public class TestController : ControllerBase
    {

       
        private readonly IBinServices _binArticleServices;
        public TestController(IBinServices BindvertisementServices)
        {
           
            this._binArticleServices = BindvertisementServices;
        }


        // GET: api/Test
        [HttpGet]
        public async Task<object> GetAsync()
        {
            var model = await _binArticleServices.GetBinList();//调用该方法，这里 _blogArticleServices 是依赖注入的实例，不是类
            var data = new { success = true, data = model };
            return data;
        }

      
    }
}
