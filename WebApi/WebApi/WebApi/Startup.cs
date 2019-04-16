using System;
using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.AOP;
using Autofac.Extras.DynamicProxy;
using Swashbuckle.AspNetCore.Swagger;

namespace WebApi
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
            services.AddMvc();


            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v0.0.1",
                    Title = ".Core API",
                    Description = "框架说明文档",
                    TermsOfService = "None",
                    Contact = new Contact { Name = ".net Core", Email = "", Url = "" }
                });
            });

            #endregion



            //缓存注入
            services.AddScoped<ICaching, MemoryCaching>();

            var builder = new ContainerBuilder();

            //注册要通过反射创建的组件


            // 注册拦截器
            builder.RegisterType<BlogCacheAOP>();


            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;//获取项目路径


            var servicesDllFile = Path.Combine(basePath, "Services.dll");//获取注入项目绝对路径
            var assemblysServices = Assembly.LoadFile(servicesDllFile);//直接采用加载文件的方法        
            //builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();//指定已扫描程序集中的类型注册为提供所有其实现的接口。

            builder.RegisterAssemblyTypes(assemblysServices)
                     .AsImplementedInterfaces()
                     .InstancePerLifetimeScope()
                     .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
                     .InterceptedBy(typeof(BlogCacheAOP));//可以直接替换拦截器




            var repositoryDllFile = Path.Combine(basePath, "Repository.dll");//获取注入项目绝对路径
            var assemblysRepository = Assembly.LoadFile(repositoryDllFile);//直接采用加载文件的方法         
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();
            

            //将services填充到Autofac容器生成器中
            builder.Populate(services);

            //使用已进行的组件登记创建新容器
            var ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);//第三方IOC接管 core内置DI容器



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });
            #endregion

            app.UseMvc();
        }
    }
}
