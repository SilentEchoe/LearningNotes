using System;
using System.Collections.Generic;
using System.Text;

namespace Log
{
    public class EventFactory: LogFactory
    {
        public override Logs Create()
        {
            return  new  EventLog();
        }



    }
}
