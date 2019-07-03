using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacDemo
{
    public class TestService : ITestService
    {
        public TestService()
        {
            MyProperty = Guid.NewGuid();
        }
        public Guid MyProperty { get; set; }
        public List<string> GetList(string a)
        {
            return new List<string>() { "LiLei", "ZhangSan", "LiSi" };
        }
    }
}
