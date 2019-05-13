using System;
using System.Collections.Generic;
using System.Text;

namespace Log
{
    public class ShangHaiFactory:AbstractFactory
    {
        public override YaBo CreateYaBo()
        {
            return  new  ShangHaiYaBo();

        }


        public override YaJia CreateYaJia()
        {
            return new ShangHaiYaJia();

        }


    }
}
