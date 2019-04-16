using System.Threading.Tasks;
using IServices;
using Microsoft.AspNetCore.Mvc;
using WebApi.AuthHelper.OverWrite;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        ISysUserInfoServices _sysUserInfoServices;

        public LoginController(ISysUserInfoServices sysUserInfoServices)
        {
            _sysUserInfoServices = sysUserInfoServices;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Login")]
        public async Task<object> GetJwtStr(string name, string pass)
        {
            string jwtStr;
            var suc = false;
            var user = await _sysUserInfoServices.GetUserRoleNameStr(name, pass);
            if (user != null)
            {
                TokenModelJWT tokenModel = new TokenModelJWT { Uid = 1, Role = user };
                jwtStr = JwtHelper.IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
                suc = true;
            }
            else
            {
                jwtStr = "login fail!!!";
            }

            return Ok(new
            {
                success = suc,
                token = jwtStr
            });

        }

    }

   
}