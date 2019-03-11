using System;
using System.Collections.Generic;
using System.Text;
using WebApiClient.DataAnnotations;

namespace Test
{
    public class UserInfo
    {
        public string Account { get; set; }

        [AliasAs("password")]
        public string Password { get; set; }

        [IgnoreSerialized]
        public string Email { get; set; }
    }
}
