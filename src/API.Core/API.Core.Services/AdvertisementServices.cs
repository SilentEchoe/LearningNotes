using API.Core.IRepository;
using API.Core.IServices;
using API.Core.Repository;
using System;

namespace API.Core.Services
{
    public class AdvertisementServices : IAdvertisementServices
    {
        IAdvertisementRepository dal = new AdvertisementRepository();

        public int Sum(int i, int j)
        {
            return dal.Sum(i, j);

        }
    }
}
