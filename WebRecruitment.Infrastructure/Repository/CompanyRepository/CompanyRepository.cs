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

        public void ChangeStatus(Guid id)
        {
            var company = _context.Companies!.Find(id);
            company.Status = COMPANYENUM.INACTIVE.ToString();
            company.Account.Status = ACCOUNTENUM.INACTIVE.ToString();
            _context.Update(company);
            _context.SaveChanges();
        }


        public async Task<Company> CreateAccountCompany(Company company)
        {

            _context.Set<Company>()!.Add(company);
            await _context.SaveChangesAsync();
            return company;

        }

        public async Task<List<Company>> GetALLCompany()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} \nERROR Repository Get All Company", ex);
            }
        }

        public async Task<Company> GetByCompanyId(Guid companyId)
        {

            var company = await _context.Companies!
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
                throw new Exception($"{company.CompanyId} is null");
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
            if (company == null)
            {
                throw new Exception("Invalid COMPANY ID");
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
                throw new Exception($"{company} is null");
            }
            return company;

        }

        public async Task<Company> UpdateCompany(Company company)
        {

            _context.Set<Company>().Update(company);
            await _context.SaveChangesAsync();
            return company;
        }

    }
}