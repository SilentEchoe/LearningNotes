using IRepository;
using IServices;
using Model.Models;

namespace Services
{
    public class DoctorServices : BaseServices<Doctor>, IDoctorServices
    {

        IDoctorRepository dal;
        public DoctorServices(IDoctorRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
    }

}
