using System;
using System.Collections.Generic;
using System.Text;

namespace Customer
{
    /// <summary>
    /// 抽象建造者
    /// </summary>
   public abstract class Builder
    {
        //装CPU
        public abstract void BuildPartCPU();

        public abstract void BuildPartMainBoard();

        public abstract Computer GetComputer();


    }






}
