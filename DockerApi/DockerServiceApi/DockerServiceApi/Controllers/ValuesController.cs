using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace DockerServiceApi.Controllers
{
    [Route("/api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values

        [HttpGet]
        [Route("GetAllDockerRun")]
        public async Task<ActionResult<string>> GetAllDockerRun()
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
                // 查询正在运行的容器数量
                var dockerCount = containers.Count().ToString();


                string a = containers[0].Image;

                return $"Docker容器数量运行数量{dockerCount}";
            }
            catch (Exception ex)
            {
                return ex.ToString();
                throw;
            }
        }


        [HttpGet]
        [Route("AddDocker")]
        public async Task<ActionResult<string>> AddDocker()
        {
            try
            {
                DockerClient client = new DockerClientConfiguration(
                        new Uri("unix:///var/run/docker.sock"))
                        .CreateClient();

              

                await client.Containers.StartWithConfigContainerExecAsync("0f3e07c0138f", new ContainerExecStartParameters
                {
                    Env = new List<string> { "ACCEPT_EULA=Y", $"SA_PASSWORD=null" },
                });


                // 在容器中执行CMD 命令
                //var execResponse = await client.Containers.ExecCreateContainerAsync(
                //"307ef337fbfd", new ContainerExecCreateParameters()
                //{
                //    Detach = false,
                //    Tty = true,
                //    Cmd = new[]
                //    {
                //        "mkdir", "/tmp/abc"
                //    }
                //});


                
                return "执行完毕";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }


        }




    }
}
