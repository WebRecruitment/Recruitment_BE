using WebRecruitment.Application.Model.Request.HrRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.Model.Response.OperationResponse;

namespace WebRecruitment.Application.IService
{
    public interface IHrService
    {
        Task<ResponseAccountHr> CreateAccountHRByPositionCompany(RequestAccountToHr requestAccountToHr);
        Task<List<ResponseAccountHr>> GetALLHr();
        Task<ResponseAccountHr> GetHrById(Guid hrId);

        Task SetStatusAccountOfHr(Guid hrId);
        Task<List<ResponseAccountHr>> SortHrByDateDesc();
        Task<List<ResponseAccountHr>> GetHrByName(string name);
        Task<List<ResponseAccountHr>> GetHrByStatus(string status);
        Task SetHrStatus(Guid hrId);
        Task<ResponseOperation> UpdateStatusApplyIdByHrId(Guid hrId, Guid operationId, string status);

    }
}
