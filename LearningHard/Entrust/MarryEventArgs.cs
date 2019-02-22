using System;
using System.Collections.Generic;
using System.Text;

namespace Entrust
{
    public class MarryEventArgs:EventArgs
    {
        public string Message;

        public MarryEventArgs(string msg)
        {
            Message = msg;
        }

    }
}
