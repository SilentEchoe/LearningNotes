using System;
using System.Collections.Generic;
using System.Text;

namespace Genericity
{
   
        // Compare<T> 为泛型类,T为类型参数
        public class Compare<T> where T : IComparable
        {

        public static T compareGeneric(T t1,T t2)
        {
            if (t1.CompareTo(t2)>0)
            {
                return t1;
            }
            else
            {
                return t2;
            }


        }



        }
}
