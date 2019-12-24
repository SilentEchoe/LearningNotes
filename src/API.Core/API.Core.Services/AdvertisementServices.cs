using API.Core.IRepository;
using API.Core.IServices;
using API.Core.Model.Models;
using API.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Core.Services
{
    public class AdvertisementServices : IAdvertisementServices
    {
        IAdvertisementRepository dal = new AdvertisementRepository();

        public int Add(BinInfo model)
        {
            return dal.Add(model);
        }

        public bool Delete(BinInfo model)
        {
            return dal.Delete(model);
        }

        public List<BinInfo> Query(Expression<Func<BinInfo, bool>> whereExpression)
        {
            return dal.Query(whereExpression);
        }

        public int Sum(int i, int j)
        {
            return dal.Sum(i, j);

        }

        public bool Update(BinInfo model)
        {
            return dal.Update(model);
        }
    }
}
