using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.IRepository.AccountRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure.GenericRepository;

namespace WebRecruitment.Infrastructure.Repository.AccountRepository
{
    public class AccountRepository : GenericRepository<Account>, IAccount
    {
        public AccountRepository(TuyendungContext context) : base(context)
        {
        }

        public async Task<Account> GetAccountByEmail(string email)
        {
            var account = await _context.Set<Account>().FirstOrDefaultAsync(x => x.Email == email);

            return account;
        }


        public async Task<Account> GetAccountById(Guid id)
        {
            var account = await _context.Set<Account>()!
                    .Include(a => a.Admins)
                    .Include(a => a.Candidates)
                    .Include(h => h.Hrs)
                    .Include(h => h.Interviewers)
                    .Include(a => a.Companies).FirstOrDefaultAsync(a => a.Accountid == id);
            if (account == null)
            {
                throw new Exception("NOT FOUND ACCOUNT");
            }
            return account;
        }

        public async Task<Account> GetAccountByUserName(string userName)
        {
            var account = await _context.Set<Account>()!.FirstOrDefaultAsync(a => a.Username == userName);
            if (account == null)
            {
                throw new Exception("NOT FOUND ACCOUNT");
            }
            return account;
        }

        public async Task<List<Account>> GetALLAccounts()
        {
            var accounts = await _context.Set<Account>()
                    .Include(a => a.Admins)
                    .Include(a => a.Candidates)
                    .Include(a => a.Companies)
                    //.Include(h => h.Hrs)
                    //.Include(h => h.Interviewers)
                    .ToListAsync();
            return accounts;
        }

    }
}
