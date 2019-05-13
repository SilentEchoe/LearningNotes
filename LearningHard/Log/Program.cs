using System;
using System.Dynamic;

namespace Log
{
    class Program
    {
        static void Main(string[] args)
        {

            AbstractFactory nanAbstractFactory = new  NanChangFactory();
            YaBo nanChangYabo = nanAbstractFactory.CreateYaBo();
            nanChangYabo.Print();

            YaJia nanChangYajia = nanAbstractFactory.CreateYaJia();
            nanChangYajia.Print();

            AbstractFactory shangHaiFactory = new ShangHaiFactory();
            shangHaiFactory.CreateYaBo().Print();
            shangHaiFactory.CreateYaJia().Print();

            Console.WriteLine("Hello World!");
            Console.Read();
        }
    }
}
