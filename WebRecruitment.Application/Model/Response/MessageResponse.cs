using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebRecruitment.Application.Model.Response.AccountResponse;

namespace WebRecruitment.Application.Model.Response
{

    public class MessageResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }

    }
    
}
