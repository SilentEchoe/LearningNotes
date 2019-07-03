using Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IServices
{
    public interface IDoctorServices : IBaseServices<Doctor>
    {
        Task<List<Doctor>> GetDoctors();
        Task<List<Doctor>> doctors();

    }
}
