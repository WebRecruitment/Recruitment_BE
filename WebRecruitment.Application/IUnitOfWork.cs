using System.Data;
using WebRecruitment.Application.Common;
using WebRecruitment.Application.IRepository.AccountRepository;
using WebRecruitment.Application.IRepository.AdminRepository;
using WebRecruitment.Application.IRepository.ApplyRepository;
using WebRecruitment.Application.IRepository.AuthenticationRepository;
using WebRecruitment.Application.IRepository.CandidateRepository;
using WebRecruitment.Application.IRepository.CompanyRepository;
using WebRecruitment.Application.IRepository.CvRepository;
using WebRecruitment.Application.IRepository.HRRepository;
using WebRecruitment.Application.IRepository.InterviewerRepository;
using WebRecruitment.Application.IRepository.JobRepository;
using WebRecruitment.Application.IRepository.PositionRepository;
using WebRecruitment.Application.IRepository.PostsRepository;

namespace WebRecruitment.Application
{
    public interface IUnitOfWork
    {
        IAccount Account { get; }
        ICompany Company { get; }
        IAdmin Admin { get; }
        ICandidate Candidate { get; }
        IPosition Position { get; }
        IHR Hr { get; }
        IInterviewer Interviewer { get; }
        IPost Post { get; }
        IJob Job { get; }
        IApply Apply { get; }
        ICv Cv { get; }
        IAuthentication Authentication { get; }
        AppConfiguration appConfiguration { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
        IDbTransaction BeginTransaction();

    }
}
