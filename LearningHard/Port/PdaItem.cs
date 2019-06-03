using System;
using System.Collections.Generic;
using System.Text;

namespace Port
{
    // 定义抽象类
    public abstract class PdaItem
    {
        public PdaItem(string name)
        {
            Name = name;
        }

        // 定义虚参数
        public virtual string Name { get; set; }

    }
}
