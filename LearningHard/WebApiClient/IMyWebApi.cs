using WebApiClient.Attributes;
using WebApiClient.DataAnnotations;

namespace WebApiClient
{


    [HttpHost("http://localhost:57960/")]
    public interface IMyWebApi : IHttpApi
    {
        [HttpGet("api/values")]
        ITask<string> GetUserByAccountAsync();

        // POST webapi/user  
        // Body Account=laojiu&password=123456
        // Return json或xml内容
        //[HttpPost("/webapi/user")]
       // ITask<UserInfo> UpdateUserWithFormAsync([FormContent] UserInfo user);
    }


}
