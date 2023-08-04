
using WebRecruitment.Application.IGenericRepository;
using WebRecruitment.Application.Model.Request.HrRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.Model.Response.OperationResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.HRRepository
{
    public interface IHR : IGenericRepository<Hr>
    {
        Task<List<Hr>> GetALLHr();
        Task<Hr> GetHrById(Guid hrId);
        Task<List<Hr>> GetHrByName(string name);
        Task<List<Hr>> GetHrByStatus(string status);

        Task<List<Hr>> GetALLHrByCompanyId(Guid companyId);



    }
}
