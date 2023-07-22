using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebRecruitment.Application;
using WebRecruitment.Application.Common.Security.Hashing;
using WebRecruitment.Application.Common.Security.Tokens;
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
using WebRecruitment.Application.IRepository.MeetingRepository;
using WebRecruitment.Application.IRepository.PositionRepository;
using WebRecruitment.Application.IRepository.PostsRepository;
using WebRecruitment.Application.IService;
using WebRecruitment.Infrastructure.Mapper;
using WebRecruitment.Infrastructure.Repository.AccountRepository;
using WebRecruitment.Infrastructure.Repository.AdminRepository;
using WebRecruitment.Infrastructure.Repository.ApplyRepository;
using WebRecruitment.Infrastructure.Repository.AuthenticationRepository;
using WebRecruitment.Infrastructure.Repository.CandidateRepository;
using WebRecruitment.Infrastructure.Repository.CompanyRepository;
using WebRecruitment.Infrastructure.Repository.CvRepository;
using WebRecruitment.Infrastructure.Repository.HrRepository;
using WebRecruitment.Infrastructure.Repository.InterviewerRepository;
using WebRecruitment.Infrastructure.Repository.JobRepository;
using WebRecruitment.Infrastructure.Repository.MeetingRepository;
using WebRecruitment.Infrastructure.Repository.PositionRepository;
using WebRecruitment.Infrastructure.Repository.PostsRepository;
using WebRecruitment.Infrastructure.Service;
using WebRecruitment.Infrastructure.Service.Security.Hashing;
using WebRecruitment.Infrastructure.Service.Security.Tokens;

namespace WebRecruitment.Infrastructure
{
    public static class DenpendencyInjection
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services, string databaseConnection, string azureBlobStorage, string containerName)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // REPOSIOTRY

            services.AddScoped<IAccount, AccountRepository>();
            services.AddScoped<IAdmin, AdminRepository>();
            services.AddScoped<IApply, ApplyRepository>();
            services.AddScoped<ICandidate, CandidateRepository>();
            services.AddScoped<ICompany, CompanyRepository>();
            services.AddScoped<ICv, CvRepository>();
            services.AddScoped<IHR, HrRepository>();
            services.AddScoped<IInterviewer, InterviewerRepository>();
            services.AddScoped<IJob, JobRepository>();
            services.AddScoped<IMeeting, MeetingRepository>();
            services.AddScoped<IPosition, PositionRepository>();
            services.AddScoped<IPost, PostsRepository>();
            services.AddScoped<IAuthentication, AuthenticationRepository>();
            services.AddScoped<ITokensHandler, TokensHandler>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            // SERVICE
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IHrService, HrService>();
            services.AddScoped<IInterviewerService, InterviewerService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IOperationService, OperationService>();
            services.AddScoped<ICvService, CvService>();
            services.AddScoped<IAuthenService, AuthenticationService>();
            services.AddScoped<IEmailService, EmailService>();

            //services.AddTransient<IAuthentication, AuthenticationRepository>();
            //services.AddTransient<IPasswordHasher, PasswordHasher>();

            services.AddDbContext<TuyendungContext>(options => options.UseSqlServer(databaseConnection));
            //// Register AppConfiguration
            services.AddScoped(_ =>
            {
                //var connectionString = new BlobContainerClient(azureBlobStorage, containerName);
                //new BlobContainerClient(azureBlobStorage, containerName);
                return new BlobServiceClient(azureBlobStorage);
            });
            //AUTOMAPPER
            services.AddAutoMapper(typeof(ApplicationMapper).Assembly);

            

            return services;
        }
    }
}
