using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace API.Core.Repository.sugar
{
    public class BaseDBConfig
    {
        public static string ConnectionString = File.ReadAllText(@"D:\my-file\dbCountPsw1.txt").Trim();

        //正常格式是

        //public static string ConnectionString = ""; 

      

    }
}
