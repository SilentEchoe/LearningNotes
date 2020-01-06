using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
     public class Subscriber
    {
        public string Name { get; set; }

        public Subscriber(string name) 
        {
            this.Name = name;
        }

        public void ReceiveAndPrintData(TenxunGame txGame)
        {
          Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, txGame.Symbol, txGame.Info);
        }
            
         


}
}
