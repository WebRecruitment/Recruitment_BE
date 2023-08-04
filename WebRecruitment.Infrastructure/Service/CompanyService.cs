using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using WebRecruitment.Application;
using WebRecruitment.Application.Common.Security.Hashing;
using WebRecruitment.Application.IRepository.InterviewerRepository;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Request.CompanyRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.Model.Response.CompanyResponse;
using WebRecruitment.Application.Model.Response.JobResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums;

namespace WebRecruitment.Infrastructure.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResponseAccountCompany> CreateAccountCompany(RequestAccountToCompany requestAccountToCompany)
        {
            var company = _mapper.Map<Company>(requestAccountToCompany);
            company.Account.HashPassword = _passwordHasher.HashPassword(requestAccountToCompany.HashPassword);
            company.Status = COMPANYENUM.INACTIVE.ToString();
            var response = _unitOfWork.Company.Add(company);
            _unitOfWork.Account.Add(company.Account);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ResponseAccountCompany>(response);
        }

        public async Task<List<ResponseAccountCompany>> GetALLCompany()
        {

            var company = await _unitOfWork.Company.GetALLCompany();
            return _mapper.Map<List<ResponseAccountCompany>>(company);

        }

        public async Task<ResponseAccountCompany> GetByCompanyId(Guid companyId)
        {

            var company = await _unitOfWork.Company.GetCompanyByAccountId(companyId);
            return _mapper.Map<ResponseAccountCompany>(company);

        }
        public async Task<ResponseAccountCompany> GetByCompanyWId(Guid? companyId)
        {

            var company = await _unitOfWork.Company.GetByCompanyWId(companyId);
            return _mapper.Map<ResponseAccountCompany>(company);

        }
        // ERRROR
        public async Task<List<ResponseCompanyJob>> GetJobResponseByCompanyId(Guid companyId)
        {

            var company = await _unitOfWork.Company.GetJobResponseByCompanyId(companyId);
            return _mapper.Map<List<ResponseCompanyJob>>(company);

        }

        public async Task<ResponseOfCompany> UpdateCompany(Guid id, UpdateRequestCompany updateRequestCompany)
        {
            var request = await _unitOfWork.Company.GetByCompanyId(id);
            var company = _mapper.Map(updateRequestCompany, request);
            var response = _unitOfWork.Company.Update(company);
            _unitOfWork.Commit();
            return _mapper.Map<ResponseOfCompany>(response);

        }

        public async Task<Position> UpdateStatusPositionByCompanyId(Guid companyId, Guid positionId, string status)
        {
            var company = await _unitOfWork.Company.GetByCompanyId(companyId);
            var position = await _unitOfWork.Position.GetPositionById(positionId);
            if (!company.CompanyId.Equals(position.CompanyId))
            {
                throw new Exception("NOT FOUND COMPANY");
            }
            position.Status = status;
            _unitOfWork.Position.Update(position);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<Position>(position);
        }

        public async Task<ResponseAccountHr> UpdateStatusHr(Guid hRId, Guid companyid, string status)
        {

            var hr = await _unitOfWork.Hr.GetHrById(hRId);

            var company = await _unitOfWork.Company.GetByCompanyId(companyid);
            if (company == null)
            {
                throw new Exception("Invalidd COMPANY ID");
            }
            if (!hr.CompanyId.Equals(company.CompanyId))
            {
                throw new Exception("HR HAS WORK WITH THIS COMPANY");
            }
            var updateHr = _unitOfWork.Hr.Update(hr);
            updateHr.Status = status;
            _unitOfWork.Commit();
            return _mapper.Map<ResponseAccountHr>(updateHr);
        }

        public async Task<ResponseAccountInterviewer> UpdateStatusInterview(Guid interviewerId, Guid companyId, string status)
        {

            var interviewer = await _unitOfWork.Interviewer.GetInterviewerById(interviewerId);
            var company = await _unitOfWork.Company.GetByCompanyId(companyId);

            if (!interviewer.CompanyId.Equals(company.CompanyId))
            {
                throw new Exception("INTERVIEWER HAS WORK WITH THIS COMPANY");

            }
            var updateInterviewer = _unitOfWork.Interviewer.Update(interviewer);
            updateInterviewer.Status = status;
            _unitOfWork.Commit();
            return _mapper.Map<ResponseAccountInterviewer>(interviewer);
        }
    }
}
