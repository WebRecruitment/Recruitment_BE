using WebRecruitment.Application.IGenericRepository;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.CompanyRepository
{
    public interface ICompany : IGenericRepository<Company>
    {
        Task<List<Company>> GetALLCompany();

        Task<Company> CreateAccountCompany(Company company);
        Task<Company> GetByCompanyId(Guid companyId);

        Task<Company> GetByCompanyWId(Guid? companyId);
        //ERROR
        Task<List<Company>> GetJobResponseByCompanyId(Guid companyId);

        Task<Company> UpdateCompany(Company company);
        public void ChangeStatus(Guid id);
    }
}
