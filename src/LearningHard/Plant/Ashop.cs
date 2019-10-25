using System;
using System.Collections.Generic;
using System.Text;

namespace Plant
{
    public class Ashop:Ishop
    {
        /// <summary>
        /// /// A类型商店租金额，天数*单价+绩效*0.005
        /// </summary>
        /// <param name="days">天数</param>
        /// <param name="dayprice">每天单价</param>
        /// <param name="performance">日平均绩效</param>
        /// <returns></returns>
        public double Getrent(int days, double dayprice, double performance)
        {
            Console.WriteLine("A商店的租金算法");
            return days * dayprice + performance * 0.01;
        }
      


    }
}
