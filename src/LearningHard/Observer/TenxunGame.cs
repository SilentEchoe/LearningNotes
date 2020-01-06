using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    //游戏订阅号
     public class TenxunGame
    {
         // 订阅者对象
      public Subscriber Subscriber { get; set; }

     public string Symbol { get; set; }

     public string Info { get; set; }

        public void Update()
         {
             if (Subscriber != null)
             {
                 // 调用订阅者对象来通知订阅者
                 Subscriber.ReceiveAndPrintData(this);
            }
         }



}
}
