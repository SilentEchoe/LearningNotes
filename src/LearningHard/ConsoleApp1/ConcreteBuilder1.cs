using System;
using System.Collections.Generic;
using System.Text;

namespace Customer
{
    //具体创建者，具体的某个人为具体创建者
    public class ConcreteBuilder1:Builder
    {
        Computer computer = new  Computer();

        public override void BuildPartCPU()
        {
            computer.Add("CPU1");
        }


        public override void BuildPartMainBoard()
        {

            computer.Add("Main board1");
        }

        public override Computer GetComputer()
        {
            return computer;
        }

    }
}
