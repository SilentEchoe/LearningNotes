using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.sugar
{
    public class BaseDBConfig
    {
        //public static string ConnectionString { get; set; }
        public static string ConnectionString = Appsettings.App(new string[] { "AppSettings", "SqlServer", "SqlServerConnection" });//获取连接字符串

    }
}
