
using WebRecruitment.Application.IGenericRepository;
using WebRecruitment.Application.Model.Request.OperationRequest;
using WebRecruitment.Application.Model.Response.OperationResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.ApplyRepository
{
    public interface IApply : IGenericRepository<Operation>
    {
        Task<Operation> CreateOperationCompany(Operation operation);
        Task<List<Operation>> GetAllOperation();
        Task<Operation> GetByOperationId(Guid operationId);
        Task CheckCvIdExistPost(Operation operation, Post post);
        Task<Operation> UpdateOperation(Operation operation);
    }
}
