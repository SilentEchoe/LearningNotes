using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Log
{
    public class EventLog:Logs
    {
        public override void Write()
        {
            Console.WriteLine("EventLog Write Success!");

        }


    }
}
