using AutoMapper;
using WebRecruitment.Application;
using WebRecruitment.Application.Common.Security.Hashing;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Infrastructure.Service
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResponseAccountAdmin> CreateAccountAdmin(RequestAccountToAdmin requestAccountToAdmin)
        {
            var request = _mapper.Map<Admin>(requestAccountToAdmin);

            request.Account.HashPassword = _passwordHasher.HashPassword(requestAccountToAdmin.HashPassword);
            var admin =  _unitOfWork.Admin.Add(request);
            return _mapper.Map<ResponseAccountAdmin>(admin);
        }

    }
}
