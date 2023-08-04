using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Request.CompanyRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.Model.Response.CompanyResponse;
using WebRecruitment.Application.Model.Response.JobResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums;
using WebRecruitment.Application.IRepository.CompanyRepository;
using WebRecruitment.Application.IRepository.AccountRepository;
using WebRecruitment.Infrastructure.GenericRepository;

namespace WebRecruitment.Infrastructure.Repository.CompanyRepository
{
    public class CompanyRepository : GenericRepository<Company>, ICompany
    {
        public CompanyRepository(TuyendungContext context) : base(context)
        {
        }

        public async Task<Company> CreateAccountCompany(Company company)
        {

            _context.Set<Company>()!.Add(company);
            return company;

        }
        public async Task<List<Company>> GetALLCompany()
        {
            
                var companies = await _context.Set<Company>()
                    .Include(c => c.Account)
                    .Include(c => c.Positions)
                    .Include(c => c.Hrs)
                    .Include(c => c.Interviewers)
                    .Include(c => c.Jobs)
                    .Include(c => c.Posts)
                    .Include(o => o.Operations)
                    //.ThenInclude(m=>m.Hr.Meetings)
                    .ToListAsync();
                return companies;
           
        }

        public async Task<Company> GetByCompanyId(Guid companyId)
        {

            var company = await _context.Set<Company>()
            .Include(c => c.Account)
            .Include(c => c.Positions)
            .Include(c => c.Hrs)
            .Include(c => c.Interviewers)
            .Include(c => c.Jobs)
            .Include(c => c.Posts)
            .Include(o => o.Operations)
            .FirstOrDefaultAsync(c => c.CompanyId == companyId);
            if (company == null)
            {
                throw new Exception("NOT FOUND COMPANY");
            }
            return company;

        }

        public async Task<Company> GetByCompanyWId(Guid? companyId)
        {

            var company = await _context.Set<Company>()!
            .Include(c => c.Account)
            .Include(c => c.Positions)
            .Include(c => c.Hrs)
            .Include(c => c.Interviewers)
            .Include(c => c.Jobs)
            .Include(c => c.Posts)
            .Include(o => o.Operations)
            .FirstOrDefaultAsync(c => c.CompanyId == companyId);
            if(company == null)
            {
                throw new Exception("NOT FOUND COMPANY");
            }
            return company;

        }

        public async Task<Company> GetCompanyByAccountId(Guid accountId)
        {
            var company = await _context.Set<Company>()!
            .Include(c => c.Account)
            .Include(c => c.Positions)
            .Include(c => c.Hrs)
            .Include(c => c.Interviewers)
            .Include(c => c.Jobs)
            .Include(c => c.Posts)
            .Include(o => o.Operations)
            .FirstOrDefaultAsync(c => c.Accountid == accountId);
            if (company == null)
            {
                throw new Exception("NOT FOUND COMPANY");
            }
            return company;
        }

        public async Task<List<Company>> GetJobResponseByCompanyId(Guid companyId)
        {

            var company = await _context.Set<Company>()!
             .Include(c => c.Jobs)
             .Where(c => c.CompanyId == companyId)
             .ToListAsync();
            if (company == null)
            {
                throw new Exception("NOT FOUND COMPANY");
            }
            return company;

        }

        

    }
}