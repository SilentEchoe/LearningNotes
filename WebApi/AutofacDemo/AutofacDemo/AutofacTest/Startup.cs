using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacDemo;
using AutofacDemo.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutofacTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var builder = new ContainerBuilder();



#pragma warning disable CS0436 // 类型与导入类型冲突
            builder.RegisterType<GuidTransientAppService>().As<IGuidTransientAppService>();
#pragma warning restore CS0436 // 类型与导入类型冲突
#pragma warning disable CS0436 // 类型与导入类型冲突
            builder.RegisterType<GuidScopedAppService>().As<IGuidScopedAppService>();
#pragma warning restore CS0436 // 类型与导入类型冲突
#pragma warning disable CS0436 // 类型与导入类型冲突
            builder.RegisterType<GuidSingletonAppService>().As<IGuidSingletonAppService>();
#pragma warning restore CS0436 // 类型与导入类型冲突
            builder.Populate(services);
            var ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
