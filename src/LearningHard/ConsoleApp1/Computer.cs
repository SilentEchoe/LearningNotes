using System;
using System.Collections.Generic;
using System.Text;

namespace Customer
{
    public class Computer
    {
        //电脑组件集合
        private IList<string> parts = new List<string>();

        public void Add(string part)
        {
            parts.Add(part);

        }

        public void Show()
        {
            Console.WriteLine("电脑开始组装.....");
            foreach (var part in parts)
            {
                Console.WriteLine("组件"+part+"已装好");
            }

            Console.WriteLine("电脑组装好了");

        }



    }
}
