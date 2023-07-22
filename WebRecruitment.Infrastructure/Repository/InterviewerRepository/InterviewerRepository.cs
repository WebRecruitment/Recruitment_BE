using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.IRepository.InterviewerRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure.GenericRepository;

namespace WebRecruitment.Infrastructure.Repository.InterviewerRepository
{
    public class InterviewerRepository : GenericRepository<Interviewer>, IInterviewer
    {
        public InterviewerRepository(TuyendungContext context) : base(context)
        {
        }

        public async Task<List<Interviewer>> GetALLInterviewer()
        {
            
            var interviewer = await _context.Set<Interviewer>()!
            .Include(a => a.Account)
            .Include(p => p.Position)
            .Include(m => m.Meetings)
            .Include(m => m.Company)
            .ToListAsync();

            return interviewer;

        }

        public async Task<Interviewer> GetInterviewerById(Guid interviewerId)
        {

            var interviewer = await _context.Set<Interviewer>()!
            .Include(a => a.Account)
            .Include(p => p.Position)
            .Include(c => c.Company)
            .ThenInclude(J => J.Jobs)
            .FirstOrDefaultAsync(i => i.InterviewerId == interviewerId);

            if (interviewer == null)
            {
                throw new Exception("INTERVIEWER IS NULL");
            }
            return interviewer;

        }
       
    }
}
