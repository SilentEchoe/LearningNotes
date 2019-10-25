
using AutoMapper;
using Model.Models;
using Model.ViewModels;
using WebApi.AutoMapper;

namespace WebApi.AutoMapper
{
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            CreateMap<BlogArticle, BlogViewModels>();
        }
    }
}
