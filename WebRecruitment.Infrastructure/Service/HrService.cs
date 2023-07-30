using AutoMapper;
using WebRecruitment.Application;
using WebRecruitment.Application.Common.Security.Hashing;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.HrRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.Model.Response.OperationResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums;

namespace WebRecruitment.Infrastructure.Service
{
    public class HrService : IHrService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public HrService(IMapper mapper, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResponseAccountHr> CreateAccountHRByPositionCompany(RequestAccountToHr requestAccountToHr)
        {

            var hr = _mapper.Map<Hr>(requestAccountToHr);
            hr.Account.HashPassword = _passwordHasher.HashPassword(requestAccountToHr.HashPassword);
            var position = await _unitOfWork.Position.GetPositionByWId(hr.PositionId);

            if (!position.NamePosition.Equals(ROLEPOSITION.HR.ToString()) || !position.Status.Equals(POSITIONENUM.ACTIVE.ToString()))
            {
                throw new Exception("Invalid Name Position or Status Not Active");
            }
            hr.CompanyId = position.CompanyId;

            var company = await _unitOfWork.Company.GetByCompanyId(hr.CompanyId);

            if (company.Status.Equals(COMPANYENUM.INACTIVE.ToString()))
            {
                throw new Exception("INACTIVE COMPANY");
            }

            hr.Status = HRENUM.INACTIVE.ToString();
            var response = _unitOfWork.Hr.Add(hr);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ResponseAccountHr>(response);

        }

        public async Task<List<ResponseAccountHr>> GetALLHr()
        {

            var repsonse = await _unitOfWork.Hr.GetALLHr();
            return _mapper.Map<List<ResponseAccountHr>>(repsonse);

        }

        public async Task<ResponseAccountHr> GetHrById(Guid hrId)
        {

            var repsonse = await _unitOfWork.Hr.GetHrById(hrId);
            return _mapper.Map<ResponseAccountHr>(repsonse);

        }

        public async Task<List<ResponseAccountHr>> GetHrByName(string name)
        {

            var response = await _unitOfWork.Hr.GetHrByName(name);
            return _mapper.Map<List<ResponseAccountHr>>(response);


        }

        public async Task<List<ResponseAccountHr>> GetHrByStatus(string status)
        {

            var response = await _unitOfWork.Hr.GetHrByStatus(status);

            return _mapper.Map<List<ResponseAccountHr>>(response);

        }

        public Task SetHrStatus(Guid hrId)
        {
            throw new NotImplementedException();
        }

        public Task SetStatusAccountOfHr(Guid hrId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseAccountHr>> SortHrByDateDesc()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseOperation> UpdateStatusApplyIdByHrId(Guid hrId, Guid operationId, string status)
        {

            var hr = await _unitOfWork.Hr.GetHrById(hrId);
            if (hr.Status.Equals(HRENUM.ACTIVE.ToString()) && !hr.Account.Status.Equals(ACCOUNTENUM.ACCEPT.ToString()))
            {
                throw new Exception("Require Company or Admin Set Status Hr");
            }
            var operation = await _unitOfWork.Apply.GetByOperationId(operationId);

            var company = await _unitOfWork.Company.GetByCompanyId(operation.CompanyId);

            if (!company.CompanyId.Equals(hr.CompanyId))
            {
                throw new Exception("AUTHOZATION HR IN COMPANY HERE");
            }

            if (!operation.CompanyId.Equals(hr.CompanyId))
            {
                throw new Exception("Company Not Match");
            }

            operation.Status = status;
            var response =  _unitOfWork.Apply.Update(operation);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ResponseOperation>(response);

        }
    }
}
