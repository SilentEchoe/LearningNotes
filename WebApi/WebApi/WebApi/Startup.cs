using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.AOP;
using Autofac.Extras.DynamicProxy;
using Common.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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

            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v0.0.1",
                    Title = ".Net Core API",
                    Description = "框架说明文档",
                    TermsOfService = "None",
                    Contact = new Contact { Name = ".Net Core", Email = "", Url = "" }
                });

                //就是这里

                #region 读取xml信息

                //var xmlPath = Path.Combine(basePath, "Blog.Core.xml");//这个就是刚刚配置的xml文件名
                //var xmlModelPath = Path.Combine(basePath, "Blog.Core.Model.xml");//这个就是Model层的xml文件名
                //c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改
                //c.IncludeXmlComments(xmlModelPath);
                #endregion

                #region
                //添加header验证信息
                //c.OperationFilter<SwaggerHeader>();

                var IssuerName = (Configuration.GetSection("Audience"))["Issuer"];

                var security = new Dictionary<string, IEnumerable<string>> { { IssuerName, new string[] { } }, };
                c.AddSecurityRequirement(security);
                //方案名称“Blog.Core”可自定义，上下一致即可
                c.AddSecurityDefinition(IssuerName, new ApiKeyScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                    Type = "apiKey"
                });
                #endregion

            });
            #endregion


            #region JWT认证
            // 1【授权】、这个和上边的异曲同工，好处就是不用在controller中，写多个 roles 。
            // 然后这么写 [Authorize(Policy = "Admin")]         
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));
            });


            //上边用到的 tokenValidationParameters 
            //读取配置文件
            var audienceConfig = Configuration.GetSection("Audience");
            var symmetricKeyAsBase64 = audienceConfig["Secret"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            // 令牌验证参数
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,//还是从 appsettings.json 拿到的
                ValidateIssuer = true,
                ValidIssuer = audienceConfig["Issuer"],//发行人
                ValidateAudience = true,
                ValidAudience = audienceConfig["Audience"],//订阅人
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
            };


            // 2.1【认证】、官方JWT认证
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = tokenValidationParameters;
                });
            #endregion


            #region Redis
            services.AddScoped<IRedisCacheManager, RedisCacheManager>();
            //这里说下，如果是自己的项目，个人更建议使用单例模式
            //services.AddSingleton 
            #endregion


            #region 缓存注入

            services.AddScoped<ICaching, MemoryCaching>();
            var builder = new ContainerBuilder();
            //注册要通过反射创建的组件
            // 注册拦截器

            builder.RegisterType<BlogCacheAOP>();//可以直接替换其他拦截器
            builder.RegisterType<BlogRedisCacheAOP>();//可以直接替换其他拦截器
            builder.RegisterType<LogAOP>();//这样可以注入第二个
            

            var servicesDllFile = Path.Combine(basePath, "Services.dll");//获取注入项目绝对路径
            var assemblysServices = Assembly.LoadFile(servicesDllFile);//直接采用加载文件的方法        
         
            builder.RegisterAssemblyTypes(assemblysServices)
                     .AsImplementedInterfaces()
                     .InstancePerLifetimeScope()
                     .EnableInterfaceInterceptors()//引用 Autofac.Extras.DynamicProxy;
                     .InterceptedBy(typeof(BlogCacheAOP));//可以直接替换拦截器

            var repositoryDllFile = Path.Combine(basePath, "Repository.dll");//获取注入项目绝对路径
            var assemblysRepository = Assembly.LoadFile(repositoryDllFile);//直接采用加载文件的方法         
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();
            

            //将services填充到Autofac容器生成器中
            builder.Populate(services);

            //使用已进行的组件登记创建新容器
            var ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);//第三方IOC接管 core内置DI容器
            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMiddleware<JwtTokenAuth>();

            app.UseAuthentication();

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
