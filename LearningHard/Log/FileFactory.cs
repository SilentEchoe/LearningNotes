using System;
using System.Collections.Generic;
using System.Text;

namespace Log
{
    public class FileFactory
    {
        public FileLog Create()
        {
            return new FileLog();
        }


    }
}
