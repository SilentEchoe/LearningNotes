using API.Core.IServices.BASE;
using API.Core.Model.Models;
using API.Core.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.IServices
{
    public interface IBinServices : IBaseServices<BinInfo>
    {
      
        Task<BinInfoViewModels> GetBinList();
    }
}
