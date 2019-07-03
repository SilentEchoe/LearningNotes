using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacDemo
{
    public interface ITestService
    {
        Guid MyProperty { get; }
        List<string> GetList(string a);
    }
}
