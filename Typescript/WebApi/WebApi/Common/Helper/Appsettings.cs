using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Linq;

namespace Common
{
    public class Appsettings
    {
        static IConfiguration Configuration { get; set; }
        static Appsettings()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
        }
        /// <summary>
        /// 封装要操作的字符
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static string App(params string[] sections)
        {
            try
            {
                var val = sections.Aggregate(string.Empty, (current, t) => current + (t + ":"));

                return Configuration[val.TrimEnd(':')];
            }
            catch (Exception)
            {
                return "";
            }

        }
    }
}
