using WebRecruitment.Application.Common.Security.Tokens;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response;
using WebRecruitment.Application.Model.Response.AuthenResponse;

namespace WebRecruitment.Application.IService
{
    public interface IAuthenService
    {
        Task<AuthenResponseMessToken> CreateAccessTokenAsync(RequestLogin requestLogin);
        Task<AuthenResponseMessToken> RefreshTokenAsync(string refreshToken, string userEmail);
        void RevokeRefreshToken(string refreshToken, string userEmail);
    }
}
