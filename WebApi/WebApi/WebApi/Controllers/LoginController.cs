using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.AuthHelper.OverWrite;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        //ISysUserInfoServices _sysUserInfoServices;

        //public LoginController(ISysUserInfoServices sysUserInfoServices)
        //{
        //    _sysUserInfoServices = sysUserInfoServices;
        //}

    

        [HttpGet]
        [Route("GetTokenNuxt")]
        public async Task<object> GetJWTStrForNuxt(string name, string pass)
        {
            string jwtStr;
            bool suc = false;
            //这里就是用户登陆以后，通过数据库去调取数据，分配权限的操作
            //这里直接写死了
            if (name == "1" && pass == "1")
            {
                TokenModelJwt tokenModel = new TokenModelJwt();
                tokenModel.Uid = 1;
                tokenModel.Role = "Admin";

                jwtStr = JwtHelper.IssueJWT(tokenModel);
                suc = true;
            }
            else
            {
                jwtStr = "login fail!!!";
            }

            return Ok(new
            {
                success = suc,
                data = new { success = suc, token = jwtStr }
            });
        }



        [HttpGet]
        [Authorize]
        [Authorize(Roles = "Admin,Client")]
        //[Authorize(Policy = "Admin")]     
        public string Get()
        {
            return "a";
      
        }

    }

   
}