using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRecruitment.Application.Common.Security.Tokens;

namespace WebRecruitment.Application.Model.Response.AuthenResponse
{
    public class AuthenResponseMessToken
    {
        public string Token { get;  set; }
        public string RefreshToken { get; set; }
        public long Expiration { get;  set; }

    }
}
