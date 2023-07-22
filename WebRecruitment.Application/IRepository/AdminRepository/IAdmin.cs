using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRecruitment.Application.IGenericRepository;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.AdminRepository
{
    public interface IAdmin : IGenericRepository<Admin>
    {
        Task<Admin> GetAdminById(Guid id);

    }
}
