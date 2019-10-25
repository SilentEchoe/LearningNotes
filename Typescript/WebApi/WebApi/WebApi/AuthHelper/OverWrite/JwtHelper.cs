using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Common;
using Microsoft.IdentityModel.Tokens;
using SqlSugar;

namespace WebApi.AuthHelper.OverWrite
{
    public class JwtHelper
    {
        /// <summary>
        /// 颁发JWT字符串
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
        public static string IssueJWT(TokenModelJwt tokenModel)
        {
            var dateTime = DateTime.UtcNow;

            //var claims = new Claim[]
            //{
            //    new Claim(JwtRegisteredClaimNames.Jti,tokenModel.Uid.ToString()),//Id
            //    new Claim("Role", tokenModel.Role),//角色
            //    new Claim(JwtRegisteredClaimNames.Iat,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),  
            new Claim(JwtRegisteredClaimNames.Exp,
                $"{new DateTimeOffset(DateTime.Now.AddSeconds(10)).ToUnixTimeSeconds()}");
            //};

            Claim[] claims = new Claim[]
                {
                    //下边为Claim的默认配置
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                //这个就是过期时间，目前是过期100秒，可自定义，注意JWT有自己的缓冲过期时间
                new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddSeconds(100)).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Iss,"WebApi"),
                new Claim(JwtRegisteredClaimNames.Aud,"wr"),
                //这个Role是官方UseAuthentication要要验证的Role，我们就不用手动设置Role这个属性了
                new Claim(ClaimTypes.Role,tokenModel.Role),
               };


            //秘钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdfsdfsrty45634kkhllghtdgdfss345t678fs"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: "WebApi",
                claims: claims,
                signingCredentials: creds);

            var jwtHandler = new JwtSecurityTokenHandler();
            var encodedJwt = jwtHandler.WriteToken(jwt);

            return encodedJwt;
        }


        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>
        public static TokenModelJwt SerializeJwt(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);
            object role;
            try
            {
                jwtToken.Payload.TryGetValue(ClaimTypes.Role, out role);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            var tm = new TokenModelJwt
            {
                Uid = (jwtToken.Id).ObjToInt(),
                Role = role != null ? role.ObjToString() : "",
            };
            return tm;
        }
    }




    /// <summary>
    /// 令牌
    /// </summary>
    public class TokenModelJwt
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// 职能
        /// </summary>
        public string Work { get; set; }

    }




}
