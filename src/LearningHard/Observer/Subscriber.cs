using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
     public class Subscriber:IObserver
    {
        public string Name { get; set; }

        public Subscriber(string name) 
        {
            this.Name = name;
        }


        public void ReceiveAndPrint(TenXun tenxun)
        {
            Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, tenxun.Symbol, tenxun.Info);
        }
    }
}
