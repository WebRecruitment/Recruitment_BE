using AutoMapper;
using WebRecruitment.Application;
using WebRecruitment.Application.Common.Security.Hashing;
using WebRecruitment.Application.Common.Security.Tokens;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AuthenResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Infrastructure.Service
{
    public class AuthenticationService : IAuthenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthenResponseMessToken> CreateAccessTokenAsync(RequestLogin requestLogin)
        {
            var request = await _unitOfWork.Account.GetAccountByUserName(requestLogin.UserName);
            //BCrypto Verify
            if (!_passwordHasher.VerifyPasswordB(requestLogin.Password, request.HashPassword))
            {
                throw new Exception("ERROR HASH PASSWORD");
            }

            var account = await _unitOfWork.Authentication.Validate(request);
           

            var response = _tokensHandler.CreateAccessToken(account);
            return _mapper.Map<AuthenResponseMessToken>(response);
        }

        public async Task<AuthenResponseMessToken> RefreshTokenAsync(string refreshToken, string userEmail)
        {
            var token = _tokensHandler.TakeRefreshToken(refreshToken, userEmail);

            if (token.Expiration < DateTime.UtcNow)
            {
                throw new Exception("Expired refresh token.");
            }

            var user = await _unitOfWork.Account.GetAccountByUserName(userEmail);

            var accessToken = _tokensHandler.CreateAccessToken(user);
            return _mapper.Map<AuthenResponseMessToken>(accessToken);
        }

        public void RevokeRefreshToken(string refreshToken, string userEmail)
        {
            _tokensHandler.RevokeRefreshToken(refreshToken, userEmail);
        }
    }

}
