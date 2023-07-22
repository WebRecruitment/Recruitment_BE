using WebRecruitment.Application.IGenericRepository;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.AccountRepository
{
    public interface IAccount : IGenericRepository<Account>
    {
        Task<List<Account>> GetALLAccounts();
        Task<Account> GetAccountById(Guid id);
        Task<Account> GetAccountByUserName(string userName);
        Task<Account> GetAccountByEmail(string email);
        
    }
}
