using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRecruitment.Application.Model.Request.HrRequest;
using WebRecruitment.Application.Model.Request.InterviewerRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.Model.Response.OperationResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IService
{
    public interface IInterviewerService
    {
        Task<List<ResponseAccountInterviewer>> GetALLInterviewer();
        Task<ResponseAccountInterviewer> CreateAccountInterviewerByPositionCompany(RequestAccountToInterviewer requestAccountToInterviewer);
        Task<ResponseOperation> UpdateStatusApplyIdByInterviewerId(Guid interviewerId, Guid operationId, string status);
    }
}
