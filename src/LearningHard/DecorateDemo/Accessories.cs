using System;
using System.Collections.Generic;
using System.Text;

namespace DecorateDemo
{
    public class Accessories:Decorator
    {
        public Accessories(Phone p) : base(p) { }

        public override void Print()
        {
            base.Print();
            AddAccessories();
        }

        /// <summary>
        /// 新的行为方法
        /// </summary>
        public void AddAccessories()
        {
            Console.WriteLine("现在苹果手机有漂亮的挂件了");
        }

    }
}
