using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application;
using WebRecruitment.Application.Common.Security.Hashing;
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

        public void ChangeStatus(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseAccountCompany> CreateAccountCompany(RequestAccountToCompany requestAccountToCompany)
        {
            var company =  _mapper.Map<Company>(requestAccountToCompany);
            company.Account.HashPassword = _passwordHasher.HashPassword(requestAccountToCompany.HashPassword);
            company.Status = COMPANYENUM.INACTIVE.ToString();
            var response = await _unitOfWork.Company.CreateAccountCompany(company);
            return _mapper.Map<ResponseAccountCompany>(response);

        }

        public async Task<List<ResponseAccountCompany>> GetALLCompany()
        {

            var company = await _unitOfWork.Company.GetALLCompany();
            return _mapper.Map<List<ResponseAccountCompany>>(company);

        }

        public async Task<ResponseAccountCompany> GetByCompanyId(Guid companyId)
        {

            var company = await _unitOfWork.Company.GetByCompanyId(companyId);
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
            var response = await _unitOfWork.Company.UpdateCompany(company);
            _unitOfWork.Commit();
            return _mapper.Map<ResponseOfCompany>(response);

        }
    }
}
