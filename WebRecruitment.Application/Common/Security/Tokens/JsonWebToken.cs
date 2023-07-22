using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRecruitment.Application.Common.Security.Tokens
{
    public abstract class JsonWebToken
    {
        public string Token { get;  set; }
        public long Expiration { get;  set; }
        public JsonWebToken(string token, long expiration)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Invalid token.");

            if (expiration <= 0)
                throw new ArgumentException("Invalid expiration.");

            Token = token;
            Expiration = expiration;
        }
        public bool IsExpired() => DateTime.UtcNow.Ticks > Expiration;

    }
}
