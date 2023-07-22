using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IService
{
    public interface IAccountService
    {
        Task<List<ResponseAllAccount>> GetResponseAllAccounts();
        Task<ResponseAllAccount> GetAccountById(Guid id);
        Task<ResponseAllAccount> ResetPassword(string token,ResetPasswordRequest resetPasswordRequest);
        Task<ResponseAllAccount> UpdateAccountStatus(Guid accountId, Guid adminId, string status);
    }
}
