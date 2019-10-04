using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<ContainerListResponse> containers = await client.Containers.ListContainersAsync(
    new ContainersListParameters()
    {
        Limit = 10,
    });
        }
    }
}
