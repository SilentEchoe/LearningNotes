using API.Core.IRepository;
using API.Core.Model.Models;
using API.Core.Model.ViewModels;
using API.Core.Repository.BASE;
using API.Core.Repository.BASE.Blog.Core.Repository.Base;
using API.Core.Repository.sugar;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Core.Repository
{
    public class AdvertisementRepository : BaseRepository<BinInfo>, IAdvertisementRepository
    {


        //private DbContext context;
        //private SqlSugarClient db;
        //private SimpleClient<BinInfo> entityDB;

        //internal SqlSugarClient Db
        //{
        //    get { return db; }
        //    private set { db = value; }
        //}
        //public DbContext Context
        //{
        //    get { return context; }
        //    set { context = value; }
        //}
        //public AdvertisementRepository()
        //{
        //    DbContext.Init(BaseDBConfig.ConnectionString);
        //    context = DbContext.GetDbContext();
        //    db = context.Db;
        //    entityDB = context.GetEntityDB<BinInfo>(db);
        //}
        //public int Add(BinInfo model)
        //{
        //    //返回的i是long类型,这里你可以根据你的业务需要进行处理
        //    var i = db.Insertable(model).ExecuteReturnBigIdentity();
        //    return i.ObjToInt();
        //}

        //public bool Delete(BinInfo model)
        //{
        //    var i = db.Deleteable(model).ExecuteCommand();
        //    return i > 0;
        //}

        //public List<BinInfo> Query(Expression<Func<BinInfo, bool>> whereExpression)
        //{
        //    return entityDB.GetList(whereExpression);

        //}

        //public int Sum(int i, int j)
        //{
        //    return i + j;
        //}

        //public bool Update(BinInfo model)
        //{
        //    //这种方式会以主键为条件
        //    var i = db.Updateable(model).ExecuteCommand();
        //    return i > 0;
        //}
       
    }
}
