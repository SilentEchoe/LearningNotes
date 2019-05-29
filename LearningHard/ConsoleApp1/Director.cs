using System;
using System.Collections.Generic;
using System.Text;

namespace Customer
{
    public class Director
    {
        /// <summary>
        /// 组装电脑
        /// </summary>
        /// <param name="builder"></param>
        public void Construst(Builder builder)
        {
            builder.BuildPartCPU();
            builder.BuildPartMainBoard();
        }


    }
}
