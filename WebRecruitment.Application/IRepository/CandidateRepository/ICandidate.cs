using WebRecruitment.Application.IGenericRepository;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.CandidateRepository
{
    public interface ICandidate : IGenericRepository<Candidate>
    {
        Task<List<Candidate>> GetALLCandidate();

        Task<Candidate> CreateAccountCandidate(Candidate candidate);
        Task<Candidate> CheckCandidateIdByCv(Cv cv);
    }
}
