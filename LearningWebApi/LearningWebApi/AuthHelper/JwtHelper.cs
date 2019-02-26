using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LearningWebApi.AuthHelper
{
    public class JwtHelper
    {
        public static string secretKey { get; set; } = "sdfsdfsrty45634kkhllghtdgdfss345t678fs";

        // public static string IssueJWT(TokenModelJWT tokenModel ) { }

        // 颁发JWT字符串
        public static string IssueJWT(TokenModelJWT tokenModel)
        {

            var dataTime = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,tokenModel.Uid.ToString()),
                new Claim("Role",tokenModel.Role),
                new Claim(JwtRegisteredClaimNames.Iat,dataTime.ToString(),ClaimValueTypes.Integer64)
            };

            //秘钥

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtHelper.secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(

                issuer: "LearningWebApi",
                claims: claims,
                expires: dataTime.AddHours(2),
                signingCredentials: creds
                );

            var jwtHandler = new JwtSecurityTokenHandler();
            var encodeedJwt = jwtHandler.WriteToken(jwt);

            return encodeedJwt;
        }


        //秘钥
        public static TokenModelJWT SerializeJWT(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken = jwtHandler.ReadJwtToken(jwtStr);
            object role = new object();

        }

    }

    /// <summary>
    /// 令牌
    /// </summary>
    public class TokenModelJWT
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
