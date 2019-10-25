using System;
using System.Collections.Generic;
using System.Text;

namespace DecorateDemo
{
    public class ApplePhone:Phone
    {
        public override void Print()
        {
            Console.WriteLine("开始执行具体的对象—苹果手机");
        }

    }
}
