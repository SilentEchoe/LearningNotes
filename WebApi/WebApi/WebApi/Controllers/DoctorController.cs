using System.Collections.Generic;
using System.Threading.Tasks;
using IServices;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Doctor")]
    public class DoctorController : Controller
    {
       
        IDoctorServices doctorServices;

        public DoctorController(IDoctorServices advertisementServices)
        {
          
            this.doctorServices = advertisementServices;
        }


        [HttpGet("{id}", Name = "Get")]
        public async Task<object> Get()
        {
       
            var model = await doctorServices.GetDoctors();
            return Ok(new
            {
                success = true,
                data = model
            });

              
        }

    }
}