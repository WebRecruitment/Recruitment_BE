using WebRecruitment.Application.IGenericRepository;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.CompanyRepository
{
    public interface ICompany : IGenericRepository<Company>
    {
        Task<List<Company>> GetALLCompany();

        Task<Company> GetByCompanyId(Guid companyId);

        Task<Company> GetByCompanyWId(Guid? companyId);
        //ERROR
        Task<List<Company>> GetJobResponseByCompanyId(Guid companyId);

    }
}
