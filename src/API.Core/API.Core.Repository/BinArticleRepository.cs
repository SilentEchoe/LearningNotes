using API.Core.IRepository;
using API.Core.Model.Models;
using API.Core.Repository.BASE.Blog.Core.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Repository
{
    public class BinArticleRepository : BaseRepository<BinInfo>, IBinArticleRepository
    {
    }
}
