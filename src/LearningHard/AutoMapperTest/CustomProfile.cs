using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperTest
{
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            CreateMap<Order, OrderDto>();
           
        }
    }
}
