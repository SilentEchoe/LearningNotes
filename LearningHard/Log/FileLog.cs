using System;
using System.Collections.Generic;
using System.Text;

namespace Log
{
    public class FileLog:Logs
    {
        public override void Write()
        {
            Console.WriteLine("FileLog Write Success!");

        }


    }
}
