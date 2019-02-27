using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningWebApi.AuthHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LearningWebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy ="Admin")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [HttpGet]
        [Route("Token2")]
        public JsonResult GetJWTstr(long id = 1, string sub = "Admin")
        {
            TokenModelJWT tokenModel = new TokenModelJWT();
            tokenModel.Uid = id;
            tokenModel.Role = sub;

            string jwtStr = JwtHelper.IssueJWT(tokenModel);
            JObject jo = (JObject)JsonConvert.DeserializeObject(jwtStr);
            return jo;

        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public JsonResult renderSuccess(Object obj)
        {
            Result result = new Result();
            result.setSuccess(true);
            result.setObj(obj);
            return Json(result);
        }

    }
}
