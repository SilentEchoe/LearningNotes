using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacDemo
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //注入测试服务
            builder.RegisterType<TestService>().As<ITestService>();

        }
    }
}
