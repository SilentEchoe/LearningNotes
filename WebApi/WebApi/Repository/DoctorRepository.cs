using IRepository;
using Model.Models;
using Repository.BASE;

namespace Repository
{
    public class DoctorRepository: BaseRepository<Doctor>, IDoctorRepository
    {
    }
}
