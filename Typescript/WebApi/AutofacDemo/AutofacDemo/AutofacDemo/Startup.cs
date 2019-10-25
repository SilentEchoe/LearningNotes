using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacDemo.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AutofacDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            ApplicationContainer = configuration;
        }

        public IConfiguration ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void IServiceProvider(IServiceCollection services)
        {




            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IGuidTransientAppService, GuidTransientAppService>();
            services.AddSingleton<IGuidScopedAppService, GuidScopedAppService>();
            services.AddScoped<IGuidSingletonAppService, GuidSingletonAppService>();


            //var builder = new ContainerBuilder();

            ////注意以下写法
            //builder.RegisterType<GuidTransientAppService>().As<IGuidTransientAppService>();
            //builder.RegisterType<GuidScopedAppService>().As<IGuidScopedAppService>().InstancePerLifetimeScope();
            //builder.RegisterType<GuidSingletonAppService>().As<IGuidSingletonAppService>().SingleInstance();

            //builder.Populate(services);
            //var ApplicationContainer = builder.Build();

            //return new AutofacServiceProvider(ApplicationContainer);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseAuthentication();

            app.UseMvc();
        }
    }
}
