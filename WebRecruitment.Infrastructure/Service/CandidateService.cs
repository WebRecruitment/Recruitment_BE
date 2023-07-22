using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRecruitment.Application;
using WebRecruitment.Application.Common.Security.Hashing;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Infrastructure.Service
{
    public class CandidateService : ICandidateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public CandidateService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResponseAccountCandidate> CreateAccountCandidate(RequestAccountToCadidate requestAccountToCadidate)
        {

            var request = _mapper.Map<Candidate>(requestAccountToCadidate);
            request.Account.HashPassword=_passwordHasher.HashPassword(request.Account.HashPassword);
            var candidate = await _unitOfWork.Candidate.CreateAccountCandidate(request);
            return _mapper.Map<ResponseAccountCandidate>(candidate);

        }

        public async Task<List<ResponseAccountCandidate>> GetAllCandidate()
        {

            var candidate = await _unitOfWork.Candidate.GetALLCandidate();
            return _mapper.Map<List<ResponseAccountCandidate>>(candidate);

        }
    }
}
