using System;
using System.Collections.Generic;
using System.Text;

namespace RedisCore
{
    public class BinFileToCisco
    {

        public long Id { get; set; }

        public string Base64 { get; set; }

        public  string FileLocation { get; set; }

        public int IsDelete { get; set; }

        public int WriteStatus { get; set; }



    }
}
