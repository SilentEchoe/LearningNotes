using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace DockerServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {

            try
            {
                DockerClient client = new DockerClientConfiguration(
                        new Uri("unix:///var/run/docker.sock"))
                        .CreateClient();
                IList<ContainerListResponse> containers = await client.Containers.ListContainersAsync(
                             new ContainersListParameters()
                             {
                                 Limit = 10,
                             });

               
                string a = containers[0].Image; 

                return containers.Count().ToString() + "——" + a;
            }
            catch (Exception ex)
            {
                return ex.ToString();
                throw;
            }
        }

      
    }
}
