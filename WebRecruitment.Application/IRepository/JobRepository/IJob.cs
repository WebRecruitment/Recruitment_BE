
using WebRecruitment.Application.IGenericRepository;
using WebRecruitment.Application.Model.Request.JobRequest;
using WebRecruitment.Application.Model.Response.JobResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.JobRepository
{
    public interface IJob : IGenericRepository<Job>
    {

        Task<Job> CreateJobByCompany(Job job);
        Task<Job> GetJobById(Guid jobId);
        Task<List<Job>> GetJobByNameSkill(string nameSkill);
        Task<List<Job>> GetAllJob();
    }
}
