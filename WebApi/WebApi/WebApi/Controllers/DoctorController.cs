using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Services;

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
        public async Task<List<Doctor>> Get(int id)
        {
            //IDoctorServices advertisementServices = new DoctorServices();

            return await advertisementServices.GetTestBySqlAsync("SELECT * FROM Doctor");

            //return await advertisementServices.Query();
        }

    }
}