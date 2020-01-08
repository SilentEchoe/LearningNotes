using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    // 订阅者接口
    public  interface IObserver
    {
        void ReceiveAndPrint(TenXun tenxun);

    }
}
