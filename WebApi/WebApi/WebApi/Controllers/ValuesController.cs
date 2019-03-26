using System.Collections.Generic;
using System.Threading.Tasks;
using IServices;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet("{id}", Name = "Get")]
        public async Task<List<Doctor>> Get(int id)
        {
            IDoctorServices advertisementServices = new DoctorServices();

            return await advertisementServices.Query(d => d.Id == id);
        }
    }
}
