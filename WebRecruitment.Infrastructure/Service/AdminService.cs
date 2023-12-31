﻿using AutoMapper;
using WebRecruitment.Application;
using WebRecruitment.Application.Common.Security.Hashing;
using WebRecruitment.Application.IRepository.PositionRepository;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums;

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
            var admin = _unitOfWork.Admin.Add(request);
            return _mapper.Map<ResponseAccountAdmin>(admin);
        }

        public async Task<ResponseAccountCompany> UpdateStatusCompany(Guid adminId, Guid companyId, string status)
        {
             await _unitOfWork.Admin.GetAdminById(adminId);
            var company = await _unitOfWork.Company.GetByCompanyId(companyId);
            company.Status = status;
            foreach(var position in company.Positions)
            {
                position.Status= POSITIONENUM.ACTIVE.ToString();
                _unitOfWork.Position.Update(position);

            }
            var updateCompany = _unitOfWork.Company.Update(company);

            await _unitOfWork.CommitAsync();
            return _mapper.Map<ResponseAccountCompany>(updateCompany);
        }
    }
}
