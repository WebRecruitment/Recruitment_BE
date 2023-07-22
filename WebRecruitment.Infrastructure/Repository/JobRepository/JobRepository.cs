using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.Model.Request.JobRequest;
using WebRecruitment.Application.Model.Response.JobResponse;

using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums;
using WebRecruitment.Application.IRepository.JobRepository;
using WebRecruitment.Application.IRepository.CompanyRepository;
using WebRecruitment.Infrastructure.GenericRepository;

namespace WebRecruitment.Infrastructure.Repository.JobRepository
{
    public class JobRepository : GenericRepository<Job>, IJob
    {
        public JobRepository(TuyendungContext context) : base(context)
        {
        }

        public async Task<List<Job>> GetAllJob()
        {
            return await _context.Set<Job>().Include(c => c.Posts).Include(c => c.Company).ToListAsync();
        }

        public async Task<Job> GetJobById(Guid jobId)
        {

            var job = await _context.Set<Job>()!
             .Include(c => c.Company)
             .Include(c => c.Posts)
             .FirstOrDefaultAsync(c => c.JobId == jobId);
            if (job == null)
            {
                throw new Exception("NOT FOUND JOB");
            }
            return job;

        }



        public async Task<List<Job>> GetJobByNameSkill(string nameSkill)
        {
            var job = await _context.Set<Job>()!
           .Include(c => c.Company)
           .ThenInclude(p => p.Posts)
           .Where(c => c.NameSkill.ToUpper().Contains(nameSkill.ToUpper())).ToListAsync();
            if (job == null)
            {
                throw new Exception("NOT FOUND JOB");
            }
            return job;


        }
    }
}
