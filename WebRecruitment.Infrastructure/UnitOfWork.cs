using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using WebRecruitment.Application;
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

namespace WebRecruitment.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TuyendungContext _context;
        private readonly IAccount _account;
        private readonly ICompany _company;
        private readonly IAdmin _admin;
        private readonly ICandidate _candidate;
        private readonly IPosition _position;
        private readonly IHR _hr;
        private readonly IInterviewer _interviewer;
        private readonly IPost _post;
        private readonly IJob _job;
        private readonly IApply _apply;
        private readonly ICv _cv;
        private readonly IAuthentication _authentication;
        private readonly AppConfiguration _appConfiguration;

        public UnitOfWork(TuyendungContext context, IAccount account, ICompany company, IAdmin admin, ICandidate candidate, IPosition position, IHR hr, IInterviewer interviewer, IPost post, IJob job, IApply apply, ICv cv, IAuthentication authentication, AppConfiguration appConfiguration)
        {
            _context = context;
            _account = account;
            _company = company;
            _admin = admin;
            _candidate = candidate;
            _position = position;
            _hr = hr;
            _interviewer = interviewer;
            _post = post;
            _job = job;
            _apply = apply;
            _cv = cv;
            _authentication = authentication;
            _appConfiguration = appConfiguration;
        }

        public IAccount Account => _account;
        public ICompany Company => _company;
        public IAdmin Admin => _admin;
        public ICandidate Candidate => _candidate;
        public IPosition Position => _position;
        public IHR Hr => _hr;
        public IInterviewer Interviewer => _interviewer;
        public IPost Post => _post;

        public IJob Job => _job;

        public IApply Apply => _apply;
        public ICv Cv => _cv;

        public IAuthentication Authentication => _authentication;

        public AppConfiguration appConfiguration => _appConfiguration;

        public IDbTransaction BeginTransaction()
        {
            var transaction = _context.Database.BeginTransaction();
            return transaction.GetDbTransaction();
        }

        public void Commit()
            => _context.SaveChanges();
        public async Task CommitAsync()
            => await _context.SaveChangesAsync();

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void Rollback()
            => _context.Dispose();

        public async Task RollbackAsync()
            => await _context.DisposeAsync();

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
