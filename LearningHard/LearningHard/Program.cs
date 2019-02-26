using System;

namespace LearningHard
{
    class Program
    {
        static void Main(string[] args)
        {
            // 值类型
            int valueType = 3;

            // 引用类型
            string reftype = "abc";

            NestedVakueTypeInRef nestedVakueTypeInRef = new NestedVakueTypeInRef();

        }
    }

    public class NestedVakueTypeInRef
    {
        // valueType 作为引用类型的一部分被分配到托管堆上
        private int valueType = 3;

        public void method()
        {
            // c被分配再线程堆栈上
            char c = 'c';
        }


    }


}
