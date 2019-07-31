using System;
using System.Collections.Generic;
using System.Text;

namespace DecorateDemo
{
    // 具体装饰者
    public class Sticker:Decorator
    {
        public Sticker(Phone p) : base(p) { }

        public override void Print()
        {
            base.Print();

            // 添加新行为
            AddSticker();
        }

        public void AddSticker()
        {
            Console.WriteLine("给手机贴膜");
        }


    }
}
