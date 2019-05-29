using System;
using Customer;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建指挥者
            Director director = new Director();
            
            Builder b1 = new  ConcreteBuilder1();
            Builder b2 = new  ConcreteBuilder2();

            director.Construst(b1);

            // 组装完，组装人员搬来组装好的电脑
            Computer computer1 = b1.GetComputer();
            computer1.Show();

            // 老板叫员工去组装第二台电脑
            director.Construst(b2);
            Computer computer2 = b2.GetComputer();
            computer2.Show();


            Console.Read();
        }
    }
}
