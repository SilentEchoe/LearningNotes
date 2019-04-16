using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.AuthHelper;
using IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.AuthHelper.OverWrite;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        //ISysUserInfoServices _sysUserInfoServices;
        //public async Task<object> GetJwtStr(string name, string pass)
        //{
        //    string jwtStr = string.Empty;
        //    bool suc = false;
        //    var user = await _sysUserInfoServices.GetUserRoleNameStr(name, pass);
        //    if (user != null)
        //    {
        //        TokenModelJwt tokenModel = new TokenModelJwt { Uid = 1, Role = user };
        //        jwtStr = JwtHelper.IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
        //        suc = true;
        //    }
        //    else
        //    {
        //        jwtStr = "login fail!!!";
        //    }

        //    return Ok(new
        //    {
        //        success = suc,
        //        token = jwtStr
        //    });
        //}

    }

   
}