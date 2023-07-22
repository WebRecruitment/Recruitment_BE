using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRecruitment.Application.Common.Security.Tokens
{
    public class RefreshToken 
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
