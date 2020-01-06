using System;
using System.Collections.Generic;
using System.Text;

namespace ChainofResponsibility.Management
{
    public class VicePresident : Approver
    {
        public VicePresident(string name)
            : base(name)
        {
        }
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 25000.0)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }
}
