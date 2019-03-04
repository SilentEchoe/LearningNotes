using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int _netxSum = 0;
            for (int i = 0; i < 30; i++)
            {             
                int a = i;
                if (a == 0)
                {
                    a++;
                }
                // 记录上一次的值
                _netxSum = a + i;
                sum += a + i;


            }
            Console.WriteLine();
        }
    }
}
