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
        public string GetJWTstr(long id = 1, string sub = "Admin")
        {
            TokenModelJWT tokenModel = new TokenModelJWT
            {
                Uid = id,
                Role = sub
            };

            string jwtStr = JwtHelper.IssueJWT(tokenModel);
            return jwtStr;

        }

       

    }
}
