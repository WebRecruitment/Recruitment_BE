using WebRecruitment.Application.IGenericRepository;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.AdminRepository
{
    public interface IAdmin : IGenericRepository<Admin>
    {
        Task<Admin> GetAdminById(Guid id);

    }
}
