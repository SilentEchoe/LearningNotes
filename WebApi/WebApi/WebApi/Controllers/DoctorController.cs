using System.Collections.Generic;
using System.Threading.Tasks;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Doctor")]
    public class DoctorController : Controller
    {
        readonly IDoctorServices _doctorServices;

        public DoctorController(IDoctorServices advertisementServices)
        {
          
            this._doctorServices = advertisementServices;
        }

        /// <summary>
        /// 查询医生列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
      
        public async Task<object> Get()
        {
       
            var model = await _doctorServices.GetDoctors();
            return Ok(new
            {
                success = true,
                data = model
            });

              
        }


    }
}