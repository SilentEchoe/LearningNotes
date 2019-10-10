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

        [HttpGet]
        [AllowAnonymous]
        [Caching(AbsoluteExpiration = 10)]//增加特性
        public async Task<object> Geta()
        {
                  
            List<Doctor> blogArticleList;

            if (redisCacheManager.Get<object>("Redis.Doctor") != null)
            {
                blogArticleList = redisCacheManager.Get<List<Doctor>>("Redis.Blog");
            }
            else
            {
               
                blogArticleList = await _doctorServices.GetDoctors();

               

                redisCacheManager.Set("Redis.Doctor", blogArticleList, TimeSpan.FromHours(2));//缓存2小时
            }

                  
            return Ok(new
            {
                success = true,
                data = blogArticleList
            }); 
        }


        [HttpGet]
        [AllowAnonymous]
        [Caching(AbsoluteExpiration = 10)]//增加特性
        [Route("api/GetaTask")]
        public async Task<object> GetaTask()
        {

            List<Doctor> blogArticleList;

            if (redisCacheManager.Get<object>("Redis.Doctor") != null)
            {
                blogArticleList = redisCacheManager.Get<List<Doctor>>("Redis.Blog");
            }
            else
            {
                blogArticleList = await _doctorServices.GetDoctors();
                redisCacheManager.Set("Redis.Doctor", blogArticleList, TimeSpan.FromHours(2));//缓存2小时
            }


            return Ok(new
            {
                success = true,
                data = blogArticleList
            });



        }
    }
}