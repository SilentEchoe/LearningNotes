using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutofacDemo;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{




    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IGuidTransientAppService _guidTransientAppService; //#构造函数注入
        //private  IGuidTransientAppService _guidTransientAppService { get; } #属性注入
        private readonly IGuidScopedAppService _guidScopedAppService;
        private readonly IGuidSingletonAppService _guidSingletonAppService;

        public ValuesController(IGuidTransientAppService guidTransientAppService,
            IGuidScopedAppService guidScopedAppService, IGuidSingletonAppService guidSingletonAppService)
        {
            _guidTransientAppService = guidTransientAppService;
            _guidScopedAppService = guidScopedAppService;
            _guidSingletonAppService = guidSingletonAppService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var TransientItem = _guidTransientAppService.GuidItem();
            var ScopedItem = _guidScopedAppService.GuidItem();
            var SingletonItem = _guidSingletonAppService.GuidItem();

            return new string[] { TransientItem.ToString() , ScopedItem.ToString(), SingletonItem.ToString() };


           
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
