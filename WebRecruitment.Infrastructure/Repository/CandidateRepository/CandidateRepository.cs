using Microsoft.EntityFrameworkCore;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Application.IRepository.CandidateRepository;
using WebRecruitment.Infrastructure.GenericRepository;

namespace WebRecruitment.Infrastructure.Repository.CandidateRepository
{
    public class CandidateRepository : GenericRepository<Candidate>, ICandidate
    {
        public CandidateRepository(TuyendungContext context) : base(context)
        {
        }
        public async Task<Candidate> CreateAccountCandidate(Candidate candidate)
        {

            _context.Set<Candidate>()!.Add(candidate);
            await _context.SaveChangesAsync();

            return candidate;
        }

        public async Task<List<Candidate>> GetALLCandidate()
        {

            var companies = await _context.Set<Candidate>()!
            .Include(c => c.Account)!
            .Include(cv => cv.Cvs)!
            .ToListAsync();
            return companies;

        }

        public async Task<Candidate> CheckCandidateIdByCv(Cv cv)
        {

            var candidate = await _context.Candidates.FirstOrDefaultAsync(c => c.CandidateId == cv.CandidateId);

            if (candidate == null)
            {
                throw new Exception("NOT FOUND CANDIDATE ID");
            }
            return candidate;

        }
    }
}
