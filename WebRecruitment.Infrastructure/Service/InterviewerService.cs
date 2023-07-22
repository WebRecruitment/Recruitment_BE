using AutoMapper;
using WebRecruitment.Application;
using WebRecruitment.Application.Common.Security.Hashing;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.HrRequest;
using WebRecruitment.Application.Model.Request.InterviewerRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.Model.Response.OperationResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums;

namespace WebRecruitment.Infrastructure.Service
{
    public class InterviewerService : IInterviewerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public InterviewerService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResponseAccountInterviewer> CreateAccountInterviewerByPositionCompany(RequestAccountToInterviewer requestAccountToInterviewer)
        {
            var interviewer = _mapper.Map<Interviewer>(requestAccountToInterviewer);
            interviewer.Account.HashPassword = _passwordHasher.HashPassword(requestAccountToInterviewer.HashPassword);
            var position = await _unitOfWork.Position.GetPositionById(interviewer.PositionId);
            if (!position.NamePosition.Equals(ROLEPOSITION.INTERVIEWER.ToString()) || !position.Status.Equals(POSITIONENUM.ACTIVE.ToString()))
            {
                throw new Exception("Invalid Name Position or Status Not Active");
            }
            interviewer.CompanyId = position.CompanyId;

            var company = await _unitOfWork.Company.GetByCompanyId(interviewer.CompanyId);

            if (company.Status.Equals(COMPANYENUM.INACTIVE.ToString()))
            {
                throw new Exception("INACTIVE COMPANY");
            }

            interviewer.Status = INTERVIEWERENUM.INACTIVE.ToString();
            await _unitOfWork.Interviewer.CreateAccountInterviewerByPositionCompany(interviewer);

            return _mapper.Map<ResponseAccountInterviewer>(interviewer);

        }

        public async Task<List<ResponseAccountInterviewer>> GetALLInterviewer()
        {

            var interviewer = await _unitOfWork.Interviewer.GetALLInterviewer();
            return _mapper.Map<List<ResponseAccountInterviewer>>(interviewer);

        }

        public async Task<ResponseOperation> UpdateStatusApplyIdByInterviewerId(Guid interviewerId, Guid operationId, RequestUpdateStatusApply requestUpdateStatusApply)
        {

            var interviewer = await _unitOfWork.Interviewer.GetInterviewerById(interviewerId);
            if (!interviewer.Status.Equals(INTERVIEWERENUM.ACTIVE.ToString()) && interviewer.Account.Status.Equals(ACCOUNTENUM.ACCEPT.ToString()))
            {
                throw new Exception("Interviewer Hasn't Set Apply Status Permission");
            }

            var operation = await _unitOfWork.Apply.GetByOperationId(operationId);

            if (!operation.Status.Equals(APPLYENUM.ACCEPT.ToString()))
            {
                throw new Exception("Apply Status Not ACCEPT");
            }
            var company = await _unitOfWork.Company.GetByCompanyId(operation.CompanyId);

            if (!company.CompanyId.Equals(interviewer.CompanyId))
            {
                throw new Exception("Not Match Company");
            }


            var updateOperation = _mapper.Map(requestUpdateStatusApply, operation);
            var response = await _unitOfWork.Apply.UpdateOperation(updateOperation);

            return _mapper.Map<ResponseOperation>(response);

        }
    }
}
