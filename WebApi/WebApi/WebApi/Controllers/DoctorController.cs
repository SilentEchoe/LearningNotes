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
        }


        [HttpGet("{id}", Name = "Get")]
        public async Task<List<Doctor>> Get()
        {
            //IDoctorServices advertisementServices = new DoctorServices();

            return await advertisementServices.GetTestBySqlAsync("SELECT * FROM Doctor");

            //return await advertisementServices.Query();
        }

    }
}