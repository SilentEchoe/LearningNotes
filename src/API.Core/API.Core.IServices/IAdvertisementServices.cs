using API.Core.IServices.BASE;
using API.Core.Model.Models;
using API.Core.Model.ViewModels;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Core.IServices
{
    public interface IAdvertisementServices:IBaseServices<BinInfo>
    {
        int Test();
        List<AdvertisementEntity> TestAOP();  
    }
}
