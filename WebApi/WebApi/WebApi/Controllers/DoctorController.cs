using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Common.Attribute;
using Common.Redis;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Doctor")]
    public class DoctorController : Controller
    {
        readonly IDoctorServices _doctorServices;

        public DoctorController(IDoctorServices advertisementServices)
        {
          
            this._doctorServices = advertisementServices;
        }

        private RedisCacheManager redisCacheManager = new RedisCacheManager();
        /// <summary>
        /// 查询医生列表
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}", Name = "Get")]
        [AllowAnonymous]
        [Caching(AbsoluteExpiration = 10)]//增加特性
        public async Task<object> Get()
        {

            var connect = Appsettings.App(new string[] { "AppSettings", "RedisCaching", "ConnectionString" });//按照层级的顺序，依次写出来

          

            List<Doctor> blogArticleList = new List<Doctor>();

            if (redisCacheManager.Get<object>("Redis.Blog") != null)
            {
                blogArticleList = redisCacheManager.Get<List<Doctor>>("Redis.Blog");
            }
            else
            {
                blogArticleList = await _doctorServices.GetDoctors();
                redisCacheManager.Set("Redis.Blog", blogArticleList, TimeSpan.FromHours(2));//缓存2小时
            }

            return blogArticleList;

            var model = await _doctorServices.GetDoctors();
            return Ok(new
            {
                success = true,
                data = model
            });

              
        }


    }
}