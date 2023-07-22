using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRecruitment.Application.Model.Response.AccountResponse
{
    public class LoginRespone
    {
        public bool Success { get; set; }
        public string Messenger { get; set; } = null!;
        public string Data { get; set; } = null!;

    }

}
