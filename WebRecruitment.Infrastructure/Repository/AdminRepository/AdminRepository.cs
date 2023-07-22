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

        public async Task<Admin> CreateAccountAdmin(Admin admin)
        {

            _context.Set<Admin>()!.Add(admin);
            await _context.SaveChangesAsync();
            return admin;

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

        //Create Account
        //public async Task<ResponseAccountAdmin> test(RequestAccountToAdmin requestAccountToAdmin)
        //{
        //    var isExist = _context.Accounts!
        //        .SingleOrDefault(d => d.Username == requestAccountToAdmin.Username);
        //    if (isExist != null)
        //    {
        //        new Exception("Username already use ! ");
        //    }
        //    var admin = _mapper.Map<Admin>(requestAccountToAdmin);
        //    //set
        //    var passwordHash = _passwordHasher.Hash(requestAccountToAdmin.HashPassword);
        //    admin.Account.HashPassword = passwordHash;
        //    //
        //    _context.Admins!.Add(admin);
        //    await _context.SaveChangesAsync();
        //    return _mapper.Map<ResponseAccountAdmin>(admin);
        //}

    }
}
