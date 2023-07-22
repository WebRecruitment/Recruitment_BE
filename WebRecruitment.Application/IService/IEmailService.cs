using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRecruitment.Application.Model.Response.AccountResponse;

namespace WebRecruitment.Application.IService
{
    public interface IEmailService
    {
         Task SendMail(string recipientEmail);

    }
}
