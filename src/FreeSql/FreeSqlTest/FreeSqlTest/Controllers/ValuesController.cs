using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeSql;
using FreeSql.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FreeSqlTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // 使用Freesql 必须要使用单例模式 


        IFreeSql fsql = new FreeSqlBuilder()
    .UseConnectionString(DataType.MySql, "Data Source=54.245.72.232;Port=13307;User ID=fsbox;Password=tzZ=xx20cfmI;Initial Catalog=fs;")
    .Build();

        [Table(Name = "conf_modal_name")]
        class Topic
        {
            [Column(IsIdentity = true, IsPrimary = true)]
            public int id { get; set; }
            public string modal_name { get; set; }
            public DateTime create_date { get; set; }

            public DateTime update_date { get; set; }

            public int is_start { get; set; }

            public int parent_id { get; set; }

        }

        [Table(Name = "config_files")]
        class config_files
        {
            [Column(IsIdentity = true, IsPrimary = true)]
            public int id { get; set; }
            public string config_file_name { get; set; }

            public string config_type { get; set; }

            public string power_delay { get; set; }

            public string page_write_delay { get; set; }

            public string config_password { get; set; }

            public string page_write_byte { get; set; }

            public string pre_operation { get; set; }

            public string post_operation { get; set; }

            public DateTime create_date { get; set; }

          

        }



        ISelect<Topic> select => fsql.Select<Topic>();

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
                
            var sql = fsql.Select<Topic>()
                .AsTable((a, b) => "(select * from conf_modal_name )")
                .Page(1, 10).ToList();


            var sql1 = select.Where(a => a.id == 1).ToList();


            return new string[] { "value1", "value2" };
        }

      
    }
}
