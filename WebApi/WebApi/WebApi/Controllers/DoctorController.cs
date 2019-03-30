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
        IDoctorServices advertisementServices;
       

        public DoctorController(IDoctorServices advertisementServices)
        {
            this.advertisementServices = advertisementServices;
            //this doctorServices = doctorServices;
        }


        [HttpGet("{id}", Name = "Get")]
        public async Task<object> Get()
        {

            var model = await advertisementServices.GetTestBySqlAsync("Select * from Doctor");
            return Ok(new
            {
                success = true,
                data = model
            });

            //return await advertisementServices.GetDoctors();          
        }

    }
}