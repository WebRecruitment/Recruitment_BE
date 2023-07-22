using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.Common.Security.Tokens
{
    public interface ITokensHandler
    {
        AccessToken CreateAccessToken(Account account);
        RefreshToken TakeRefreshToken(string token, string userName);
        void RevokeRefreshToken(string token, string userName);
        Task<string> ClaimsFromToken(string token);

    }
}
