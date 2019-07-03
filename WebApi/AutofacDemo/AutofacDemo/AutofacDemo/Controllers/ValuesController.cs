using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AutofacDemo.Controllers
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

        [HttpGet]
        public object Get()
        {
            var TransientItem = _guidTransientAppService.GuidItem();
            var ScopedItem = _guidScopedAppService.GuidItem();
            var SingletonItem = _guidSingletonAppService.GuidItem();

            return TransientItem + "," + ScopedItem + "," + SingletonItem;

        }



    }
}
