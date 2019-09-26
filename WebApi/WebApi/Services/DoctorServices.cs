using Common.Helper;
using IRepository;
using IServices;
using Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class DoctorServices : BaseServices<Doctor>, IDoctorServices
    {
        readonly IDoctorRepository dal;
        public DoctorServices(IDoctorRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 10)]
        public async Task<List<Doctor>> GetDoctors()
        {
            var bloglist = await dal.GetTestBySql("Select * from Doctor");

            return bloglist;

        }


        /// <summary>
        /// 连表查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 10)]
        public async Task<List<Doctor>> GetDoctor()
        {
            

        }


    }

}
