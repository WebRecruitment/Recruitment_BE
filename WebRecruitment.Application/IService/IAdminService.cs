using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IService
{
    public interface IAdminService
    {
        Task<ResponseAccountAdmin> CreateAccountAdmin(RequestAccountToAdmin requestAccountToAdmin);

    }
}
