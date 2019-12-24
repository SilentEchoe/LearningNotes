using API.Core.IRepository;
using API.Core.IServices;
using API.Core.Model.Models;
using API.Core.Repository;
using API.Core.Services.BASE;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Core.Services
{
    public class AdvertisementServices : BaseServices<BinInfo>, IAdvertisementServices
    {

        public int Test() {
            return 1;
        }
      
    }
}
