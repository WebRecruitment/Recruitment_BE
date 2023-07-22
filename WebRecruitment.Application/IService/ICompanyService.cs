using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Request.CompanyRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.Model.Response.CompanyResponse;
using WebRecruitment.Application.Model.Response.JobResponse;

namespace WebRecruitment.Application.IService
{
    public interface ICompanyService
    {
        Task<List<ResponseAccountCompany>> GetALLCompany();

        Task<ResponseAccountCompany> CreateAccountCompany(RequestAccountToCompany requestAccountToCompany);
        Task<ResponseAccountCompany> GetByCompanyId(Guid companyId);

        Task<ResponseAccountCompany> GetByCompanyWId(Guid? companyId);

        Task<List<ResponseCompanyJob>> GetJobResponseByCompanyId(Guid companyId);

        Task<ResponseOfCompany> UpdateCompany(Guid id, UpdateRequestCompany updateRequestCompany);
        Task<ResponseAccountInterviewer> UpdateStatusInterview(Guid interviewerId, Guid companyId,string status);
        Task<ResponseAccountHr> UpdateStatusHr(Guid hRId, Guid companyid, string status);

        public void ChangeStatus(Guid id);
    }
}
