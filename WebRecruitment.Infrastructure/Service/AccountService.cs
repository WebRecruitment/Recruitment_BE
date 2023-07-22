using AutoMapper;
using WebRecruitment.Application;
using WebRecruitment.Application.Common.Security.Hashing;
using WebRecruitment.Application.Common.Security.Tokens;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Infrastructure.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;
        private readonly IPasswordHasher _passwordHasher;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResponseAllAccount> GetAccountById(Guid id)
        {
            var account = await _unitOfWork.Account.GetAccountById(id);
            return _mapper.Map<ResponseAllAccount>(account);
        }

        public async Task<List<ResponseAllAccount>> GetResponseAllAccounts()
        {
            var account = await _unitOfWork.Account.GetALLAccounts();
            return _mapper.Map<List<ResponseAllAccount>>(account);
        }

        public async Task<ResponseAllAccount> ResetPassword(string token, ResetPasswordRequest resetPasswordRequest)
        {
            var email = await _tokensHandler.ClaimsFromToken(token);
            var account = await _unitOfWork.Account.GetAccountByEmail(email);
            var mapper = _mapper.Map(resetPasswordRequest, account);
            mapper.HashPassword = _passwordHasher.HashPassword(resetPasswordRequest.Password);
            _unitOfWork.Account.Update(mapper);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ResponseAllAccount>(mapper);
        }

        public async Task<ResponseAllAccount> UpdateAccountStatus(Guid accountId, Guid adminId, string status)
        {
            var admin = await _unitOfWork.Admin.GetAdminById(adminId);
            var account = await _unitOfWork.Account.GetAccountById(accountId);
            account.Status = status;
            return _mapper.Map<ResponseAllAccount>(account);
        }
    }
}
