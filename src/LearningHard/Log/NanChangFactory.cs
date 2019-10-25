using System;
using System.Collections.Generic;
using System.Text;

namespace Log
{
    public class NanChangFactory : AbstractFactory
    {

        // 制作南昌鸭脖
        public override YaBo CreateYaBo()
        {
            return new NanChangYaBo();
        }

        public override YaJia CreateYaJia()
        {
            return new NanChangYaJia();
        }
    }
}
