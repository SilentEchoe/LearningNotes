using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperDemo
{
    public class Order
    {
        public Customer Customer { get; set; }
        public decimal GetTotal()
        {
            return 10 * 10;
        }
    }
    public class Customer
    {
        public string Name { get; set; }
    }
}
