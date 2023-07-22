using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRecruitment.Application.Model.Request.OperationRequest;
using WebRecruitment.Application.Model.Response.OperationResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IService
{
    public interface IOperationService
    {
        Task<ResponseOperation> CreateOperationCompany(RequestCreateOperation requestCreateOperation);
        Task<List<ResponseOperation>> GetAllOperation();
        Task<ResponseOperation> GetByOperationId(Guid operationId);
    }
}
