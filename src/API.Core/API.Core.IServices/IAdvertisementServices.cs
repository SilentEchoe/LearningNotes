using API.Core.IServices.BASE;
using API.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Core.IServices
{
    public interface IAdvertisementServices:IBaseServices<BinInfo>
    {
        //int Sum(int i, int j);
        //int Add(BinInfo model);
        //bool Delete(BinInfo model);
        //bool Update(BinInfo model);
        //List<BinInfo> Query(Expression<Func<BinInfo, bool>> whereExpression);

        int Test();
        List<AdvertisementEntity> TestAOP();
    }
}
