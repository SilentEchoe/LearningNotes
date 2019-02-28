using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LearningWebApi.AuthHelper
{
    public class JwtHelper
    {
        public static string SecretKey { get; set; } = "sdfsdfsrty45634kkhllghtdgdfss345t678fs";
        /// <summary>
        /// 颁发JWT字符串
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
        public static string IssueJWT(TokenModelJWT tokenModel)
        {
            var dateTime = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,tokenModel.Uid.ToString()),//Id
                new Claim("Role", tokenModel.Role),//角色
                new Claim(JwtRegisteredClaimNames.Iat,dateTime.ToString(),ClaimValueTypes.Integer64)
            };
            //秘钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: "Blog.Core",
                claims: claims, //声明集合
                expires: dateTime.AddHours(2),
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
        public static TokenModelJWT SerializeJWT(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);
           
            object role = new object(); ;
            try
            {
                jwtToken.Payload.TryGetValue("Role", out role);
            }
            catch (Exception e)
            {
                string a = e.ToString();
                Console.WriteLine(e);
                throw;
            }
            var tm = new TokenModelJWT
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
