using WebRecruitment.Application.IGenericRepository;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.AuthenticationRepository
{
    public interface IAuthentication : IGenericRepository<Account> 
    {
        Task<Account> Validate(Account account);
    }
}
