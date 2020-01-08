using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public abstract class TenXun
    {
        // 保存订阅者列表
        private List<IObserver> observers = new List<IObserver>();
        public string Symbol { get; set; }

        public string Info { get; set; }

        public TenXun(string symbol,string info) 
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        public void AddObserver(IObserver ob) 
        {
            observers.Add(ob);
        }

        public void RemoveObserver(IObserver ob) 
        {
            observers.Remove(ob);
        }

        public void Update() 
        {
            foreach (IObserver ob in observers)
            {
                if (ob != null)
                {
                    ob.ReceiveAndPrint(this);
                }

            }
        
        }


    }
}
