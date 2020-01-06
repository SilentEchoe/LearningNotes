using System;
using System.Collections.Generic;
using System.Text;

namespace ChainofResponsibility
{
    // 定义抽象类
    // 审批人,Handler
    public abstract class Approver
    {
        public Approver NextApprover { get; set; }

        public string Name { get; set; }
        public Approver(string name)
        {
            this.Name = name;
        }

        // 定义抽象方法
        public abstract void ProcessRequest(PurchaseRequest request);

    }
}
