using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperTest
{
    public class Test
    {
        public Test() {

            List<Order> orders = new List<Order>();
            Order order = new Order()
            {
                id = 1,
                name = "a"
            };
            orders.Add(order);
            OrderDto models = IMapper.Map<OrderDto>(order);
           
        }



    }
}
