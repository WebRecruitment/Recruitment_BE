using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.IRepository.AdminRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure.GenericRepository;

namespace WebRecruitment.Infrastructure.Repository.AdminRepository
{
    public class AdminRepository : GenericRepository<Admin>, IAdmin
    {
        public AdminRepository(TuyendungContext context) : base(context)
        {
        }

      

        public async Task<Admin> GetAdminById(Guid id)
        {
            var admin = await _context.Set<Admin>()!.FirstOrDefaultAsync(c => c.AdminId == id);
            if (admin == null)
            {
                throw new Exception("Admin Id Null");
            }
            return admin;
        }

       

    }
}
