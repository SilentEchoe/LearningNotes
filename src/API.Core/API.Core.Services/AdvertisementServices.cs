using API.Core.Common;
using API.Core.IRepository;
using API.Core.IServices;
using API.Core.Model.Models;
using API.Core.Services.BASE;
using System.Collections.Generic;

namespace API.Core.Services
{
    public class AdvertisementServices : BaseServices<BinInfo>, IAdvertisementServices
    {

        IAdvertisementRepository dal;
        
        public AdvertisementServices(IAdvertisementRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
            
        }

        public int Test() {
            return 1;
        }

        [Caching(AbsoluteExpiration =10)]//增加特性
        public List<AdvertisementEntity> TestAOP() => new List<AdvertisementEntity>() { new AdvertisementEntity() { id = 1, name = "laozhang" } };

        
    }
}
