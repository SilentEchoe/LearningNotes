using System;
using System.Collections.Generic;
using System.Text;

namespace Entrust
{
    public class Friend
    {
        public string Name;

        public Friend(string name)
        {
            Name = name;
        }

        // 事件处理函数，该函数需要符合MarryHandler委托的定义
        public void SendMessage(object s, MarryEventArgs e)
        { 
            //输出通知信息
            Console.WriteLine(e.Message);

            //对事件做出处理
            Console.WriteLine(this.Name + "收到了");
        }

    }
}
