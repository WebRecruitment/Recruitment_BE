using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.IRepository.AuthenticationRepository;

using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure.GenericRepository;

namespace WebRecruitment.Infrastructure.Repository.AuthenticationRepository
{
    public class AuthenticationRepository : GenericRepository<Account>, IAuthentication
    {
        public AuthenticationRepository(TuyendungContext context) : base(context)
        {
        }

        public async Task<Account> Validate(Account account)
        {
            var login = await _context.Set<Account>().
                SingleOrDefaultAsync(p => p.Username == account.Username && p.HashPassword == account.HashPassword);
            if (login == null)
            {
                throw new Exception("Invalid username/password");
            }
            return login;

        }

    }
}
