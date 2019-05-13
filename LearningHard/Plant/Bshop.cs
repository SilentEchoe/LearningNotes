using System;
using System.Collections.Generic;
using System.Text;

namespace Plant
{
    /// <summary>
    /// 继承商店接口，实现里面的行为方法，即算法
    /// </summary>
    public class Bshop : Ishop
    {
        /// <summary>
        /// B类型商店的租金=月份*(每月价格+performance*0.001)
        /// </summary>
        /// <param name="month">月数</param>
        /// <param name="monthprice">月单价</param>
        /// <param name="performance">月平均绩效</param>
        /// <returns></returns>
        public double Getrent(int month, double monthprice, double performance)
        {
            Console.WriteLine("B商店的租金算法");
            return month * (monthprice + performance * 0.001);
        }
    }

}
