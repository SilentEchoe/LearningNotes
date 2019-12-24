using API.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Core.IRepository
{
    public interface IAdvertisementRepository
    {
        int Sum(int i, int j);

        int Add(BinInfo model);
        bool Delete(BinInfo model);
        bool Update(BinInfo model);
        List<BinInfo> Query(Expression<Func<BinInfo, bool>> whereExpression);

    }
}
