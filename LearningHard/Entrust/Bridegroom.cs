using System;
using System.Collections.Generic;
using System.Text;

namespace Entrust
{
    public class Bridegroom
    {
        // 自定义委托类型，委托包含两个参数
        public delegate void MarryHandler(object sender, MarryEventArgs e);

        //定义事件
        public event MarryHandler MarryEvent;

        //发出事件
        public void OnBirthdayComing(string msg)
        {
            // 判断是否绑定了事件处理方法
            if (MarryEvent != null)
            {
                //触发事件
                MarryEvent(this, new MarryEventArgs(msg));
            }
        }

    }
}
