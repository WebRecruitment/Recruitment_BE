using AutoMapper;
using WebRecruitment.Application.Common;
using WebRecruitment.Application.Common.Security.Tokens;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Request.AuthenRequest;
using WebRecruitment.Application.Model.Request.CompanyRequest;
using WebRecruitment.Application.Model.Request.CvRequest;
using WebRecruitment.Application.Model.Request.HrRequest;
using WebRecruitment.Application.Model.Request.InterviewerRequest;
using WebRecruitment.Application.Model.Request.JobRequest;
using WebRecruitment.Application.Model.Request.OperationRequest;
using WebRecruitment.Application.Model.Request.PostRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.Model.Response.AuthenResponse;
using WebRecruitment.Application.Model.Response.CompanyResponse;
using WebRecruitment.Application.Model.Response.CvResponse;
using WebRecruitment.Application.Model.Response.JobResponse;
using WebRecruitment.Application.Model.Response.OperationResponse;
using WebRecruitment.Application.Model.Response.PostResponse;

using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums;

namespace WebRecruitment.Infrastructure.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ResetPasswordRequest, Account>()
                .ForMember(re => re.HashPassword, act => act.MapFrom(src => src.Password));

            CreateMap<Account, ResponseAllAccount>()
                .ForMember(re => re.AdminId, act => act.MapFrom(src => src.Admins.Select(p => p.AdminId).FirstOrDefault()))
                .ForMember(re => re.CandidateId, act => act.MapFrom(src => src.Candidates.Select(p => p.CandidateId).FirstOrDefault()))
                .ForMember(re => re.CompanyId, act => act.MapFrom(src => src.Companies.Select(p => p.CompanyId).SingleOrDefault()))
                .ForMember(re => re.HrId, act => act.MapFrom(src => src.Hrs.Select(p => p.HrId).SingleOrDefault()))

                .ForMember(re => re.AccountId, act => act.MapFrom(src => src.Accountid))
                .ForMember(re => re.Username, act => act.MapFrom(src => src.Username))
                .ForMember(re => re.Role, act => act.MapFrom(src => src.Role))
                .ForMember(re => re.FirstName, act => act.MapFrom(src => src.FirstName))
                .ForMember(re => re.LastName, act => act.MapFrom(src => src.LastName))
                .ForMember(re => re.Date, act => act.MapFrom(src => src.Birthday))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.Status))
                .ForMember(re => re.HashPassword, act => act.MapFrom(src => src.HashPassword))
                .ForMember(re => re.Phone, act => act.MapFrom(src => src.Phone))
                .ForMember(re => re.Email, act => act.MapFrom(src => src.Email))
                .ForMember(re => re.Address, act => act.MapFrom(src => src.Address))
                .ForMember(re => re.Gender, act => act.MapFrom(src => src.Gender))
                .ForMember(re => re.Bio, act => act.MapFrom(src => src.Bio))
                .ForMember(re => re.Language, act => act.MapFrom(src => src.Language))
                .ForMember(re => re.Nationality, act => act.MapFrom(src => src.Nationality));

            CreateMap<Pagination<Post>, Pagination<ResponsePostCompany>>();

            CreateMap<RequestAccountToCompany, Company>()
                .ForMember(c => c.ContactNumber, act => act.MapFrom(src => src.ContactNumber))
                .ForMember(c => c.NameCompany, act => act.MapFrom(src => src.NameCompany))
                .ForMember(c => c.Account, act => act.MapFrom(src => new Account
                {
                    Username = src.Username,
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Birthday = src.Date,
                    HashPassword = src.HashPassword,
                    Role = ROLEACCOUNT.COMPANY.ToString(),
                    Status = ACCOUNTENUM.ACTIVE.ToString(),
                    Phone = src.Phone,
                    Address = src.Address,
                    Email = src.Email

                }))
                 .ForPath(c => c.Positions, act => act.MapFrom(src => new List<Position>
                    {
                        new Position
                        {
                            NamePosition = ROLEPOSITION.HR.ToString(),
                            Status = POSITIONENUM.INACTIVE.ToString(),
                            CreateDate = DateTime.Now,

                        },

                        new Position
                        {
                            NamePosition = ROLEPOSITION.INTERVIEWER.ToString(),
                            Status = POSITIONENUM.INACTIVE.ToString(),
                            CreateDate = DateTime.Now,
                        }
                 }));

            CreateMap<Company, ResponseAccountCompany>()
                .ForMember(re => re.CompanyId, act => act.MapFrom(src => src.CompanyId))
                .ForMember(re => re.AccountId, act => act.MapFrom(src => src.Accountid))
                .ForMember(re => re.PositionId, act => act.MapFrom(src => src.Positions.Select(p => p.PositionId).ToList()))
                .ForMember(re => re.NamePosition, act => act.MapFrom(src => src.Positions.Select(p => p.NamePosition).ToList()))
                .ForMember(re => re.Username, act => act.MapFrom(src => src.Account!.Username))
                .ForMember(re => re.Role, act => act.MapFrom(src => src.Account!.Role))
                .ForMember(re => re.FirstName, act => act.MapFrom(src => src.Account!.FirstName))
                .ForMember(re => re.LastName, act => act.MapFrom(src => src.Account!.LastName))
                .ForMember(re => re.Date, act => act.MapFrom(src => src.Account!.Birthday))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.Account!.Status))
                .ForMember(re => re.StatusCompany, act => act.MapFrom(src => src.Status))
                .ForMember(re => re.Role, act => act.MapFrom(src => src.Account!.Role))
                .ForMember(re => re.HashPassword, act => act.MapFrom(src => src.Account!.HashPassword))
                .ForPath(re => re.Phone, act => act.MapFrom(src => src.Account!.Phone))
                .ForPath(re => re.Address, act => act.MapFrom(src => src.Account!.Address))
                .ForPath(re => re.Email, act => act.MapFrom(src => src.Account!.Email))
                .ForMember(re => re.HrId, act => act.MapFrom(src => src.Hrs.Select(hr => hr.HrId).ToList()))
                .ForMember(re => re.InterviewerId, act => act.MapFrom(src => src.Interviewers.Select(interviewer => interviewer.InterviewerId).ToList()))
                .ForMember(re => re.JobId, act => act.MapFrom(src => src.Jobs.Select(job => job.JobId).ToList()))
                .ForMember(re => re.PostId, act => act.MapFrom(src => src.Posts.Select(post => post.PostId).ToList()))
                .ForMember(re => re.OperationId, act => act.MapFrom(src => src.Operations.Select(o => o.OperationId).ToList()));
            //.ForMember(re => re.MeetingId, act => act.MapFrom(src => src.Hrs.Select(i => i.Meetings.Select(m=>m.MeetId)).ToList()));


            CreateMap<RequestAccountToHr, Hr>()
              .ForMember(hr => hr.Account, act => act.MapFrom(src => new Account
              {
                  Username = src.Username,
                  FirstName = src.FirstName,
                  LastName = src.LastName,
                  Birthday = src.Date,
                  HashPassword = src.HashPassword,
                  Role = ROLEACCOUNT.COMPANY.ToString(),
                  Status = ACCOUNTENUM.REQUEST.ToString(),
                  Email = src.Email

              }))
              .ForMember(hr => hr.NameHr, act => act.MapFrom(src => src.NameHr))
              .ForMember(hr => hr.PositionId, act => act.MapFrom(src => src.PositionId));


            CreateMap<Hr, ResponseAccountHr>()
                .ForMember(re => re.HrId, act => act.MapFrom(src => src.HrId))
                .ForMember(re => re.AccountId, act => act.MapFrom(src => src.Account!.Accountid))
                .ForMember(re => re.CompanyId, act => act.MapFrom(src => src.Company.CompanyId))
                .ForMember(re => re.PositionId, act => act.MapFrom(src => src.PositionId))
                .ForMember(re => re.Username, act => act.MapFrom(src => src.Account!.Username))
                .ForMember(re => re.Role, act => act.MapFrom(src => src.Account!.Role))
                .ForMember(re => re.NameHr, act => act.MapFrom(src => src.NameHr))
                .ForMember(re => re.FirstName, act => act.MapFrom(src => src.Account!.FirstName))
                .ForMember(re => re.LastName, act => act.MapFrom(src => src.Account!.LastName))
                .ForMember(re => re.Date, act => act.MapFrom(src => src.Account!.Birthday))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.Account!.Status))
                .ForMember(re => re.StatusHr, act => act.MapFrom(src => src.Status))
                .ForMember(re => re.Role, act => act.MapFrom(src => src.Account!.Role))
                .ForMember(re => re.HashPassword, act => act.MapFrom(src => src.Account!.HashPassword))
                .ForMember(re => re.Phone, act => act.MapFrom(src => src.Account.Phone))
                .ForMember(re => re.Email, act => act.MapFrom(src => src.Account!.Email));

            CreateMap<RequestAccountToCadidate, Candidate>()
                .ForMember(ca => ca.Account, act => act.MapFrom(src => new Account
                {
                    Username = src.Username,
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Birthday = src.Date,
                    HashPassword = src.HashPassword,
                    Email = src.Email,
                    Role = ROLEACCOUNT.CANDIDATE.ToString(),
                    Status = ACCOUNTENUM.ACTIVE.ToString(),
                    Gender = src.Gender,
                    Phone = src.Phone,
                    Address = src.Address,

                }));
            CreateMap<Candidate, ResponseAccountCandidate>()
                .ForMember(re => re.CandidateId, act => act.MapFrom(src => src.CandidateId))
                .ForMember(re => re.AccountId, act => act.MapFrom(src => src.Accountid))
                .ForMember(re => re.CvId, act => act.MapFrom(src => src.Cvs.Select(ca => ca.CvId).ToList()))
                .ForMember(re => re.Username, act => act.MapFrom(src => src.Account.Username))
                .ForMember(re => re.Role, act => act.MapFrom(src => src.Account.Role))
                .ForMember(re => re.FirstName, act => act.MapFrom(src => src.Account.FirstName))
                .ForMember(re => re.LastName, act => act.MapFrom(src => src.Account.LastName))
                .ForMember(re => re.Date, act => act.MapFrom(src => src.Account.Birthday))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.Account.Status))
                .ForMember(re => re.Role, act => act.MapFrom(src => src.Account.Role))
                .ForMember(re => re.HashPassword, act => act.MapFrom(src => src.Account.HashPassword))
                .ForMember(re => re.Phone, act => act.MapFrom(src => src.Account.Phone))
                .ForMember(re => re.Address, act => act.MapFrom(src => src.Account.Address))
                .ForMember(re => re.Email, act => act.MapFrom(src => src.Account.Email));

            CreateMap<RequestAccountToAdmin, Admin>()
               .ForMember(ad => ad.Account, act => act.MapFrom(src => new Account
               {
                   Username = src.Username,
                   FirstName = src.FirstName,
                   LastName = src.LastName,
                   Birthday = src.Date,
                   HashPassword = src.HashPassword,
                   Email = src.Email,
                   Role = ROLEACCOUNT.ADMIN.ToString(),
                   Status = ACCOUNTENUM.ACTIVE.ToString(),
                   Gender = src.Gender,
                   Phone = src.Phone,
                   Address = src.Address,
               }));
            CreateMap<Admin, ResponseAccountAdmin>()
             .ForMember(re => re.AdminId, act => act.MapFrom(src => src.AdminId))
             .ForMember(re => re.AccountId, act => act.MapFrom(src => src.Accountid))
             .ForMember(re => re.Username, act => act.MapFrom(src => src.Account.Username))
             .ForMember(re => re.Role, act => act.MapFrom(src => src.Account.Role))
             .ForMember(re => re.FirstName, act => act.MapFrom(src => src.Account.FirstName))
             .ForMember(re => re.LastName, act => act.MapFrom(src => src.Account.LastName))
             .ForMember(re => re.Date, act => act.MapFrom(src => src.Account.Birthday))
             .ForMember(re => re.Status, act => act.MapFrom(src => src.Account.Status))
             .ForMember(re => re.Role, act => act.MapFrom(src => src.Account.Role))
             .ForMember(re => re.HashPassword, act => act.MapFrom(src => src.Account.HashPassword))
             .ForMember(re => re.Phone, act => act.MapFrom(src => src.Account.Phone))
             .ForMember(re => re.Address, act => act.MapFrom(src => src.Account.Address))
             .ForMember(re => re.Email, act => act.MapFrom(src => src.Account!.Email));

            CreateMap<RequestAccountToInterviewer, Interviewer>()
               .ForMember(hr => hr.Account, act => act.MapFrom(src => new Account
               {
                   Username = src.Username,
                   FirstName = src.FirstName,
                   LastName = src.LastName,
                   Birthday = src.Date,
                   HashPassword = src.HashPassword,
                   Role = ROLEACCOUNT.COMPANY.ToString(),
                   Status = ACCOUNTENUM.REQUEST.ToString(),
                   Email = src.Email

               }))
              .ForMember(hr => hr.NameInterviewer, act => act.MapFrom(src => src.NameInterviewer))
              .ForMember(hr => hr.PositionId, act => act.MapFrom(src => src.PositionId));

            CreateMap<Interviewer, ResponseAccountInterviewer>()

               .ForMember(re => re.InterviewerId, act => act.MapFrom(src => src.InterviewerId))
               .ForMember(re => re.AccountId, act => act.MapFrom(src => src.Account!.Accountid))
               .ForMember(re => re.CompanyId, act => act.MapFrom(src => src.Company.CompanyId))
                .ForMember(re => re.PositionId, act => act.MapFrom(src => src.PositionId))
               .ForMember(re => re.Username, act => act.MapFrom(src => src.Account!.Username))
               .ForMember(re => re.Role, act => act.MapFrom(src => src.Account!.Role))
               .ForMember(re => re.FirstName, act => act.MapFrom(src => src.Account!.FirstName))
               .ForMember(re => re.LastName, act => act.MapFrom(src => src.Account!.LastName))
               .ForMember(re => re.Date, act => act.MapFrom(src => src.Account!.Birthday))
               .ForMember(re => re.Status, act => act.MapFrom(src => src.Account!.Status))
               .ForMember(re => re.StatusInterviewer, act => act.MapFrom(src => src.Status))
               .ForMember(re => re.Role, act => act.MapFrom(src => src.Account!.Role))
               .ForMember(re => re.HashPassword, act => act.MapFrom(src => src.Account!.HashPassword))
                .ForMember(re => re.Phone, act => act.MapFrom(src => src.Account.Phone))
                .ForMember(re => re.Email, act => act.MapFrom(src => src.Account!.Email));

            //=================================================================================
            CreateMap<RequestJobCompany, Job>()
               .ForMember(hr => hr.CompanyId, act => act.MapFrom(src => src.CompanyId))
               .ForMember(hr => hr.Description, act => act.MapFrom(src => src.Description))
               .ForMember(hr => hr.NameSkill, act => act.MapFrom(src => src.NameSkill));

            CreateMap<Job, ResponseJobCompany>()
               .ForMember(hr => hr.JobId, act => act.MapFrom(src => src.JobId))
               .ForMember(hr => hr.CompanyId, act => act.MapFrom(src => src.CompanyId))
               .ForMember(hr => hr.Description, act => act.MapFrom(src => src.Description))
               .ForMember(hr => hr.NameSkill, act => act.MapFrom(src => src.NameSkill))
               .ForMember(hr => hr.Status, act => act.MapFrom(src => src.Status));


            CreateMap<Company, ResponseCompanyJob>()
               .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
               .ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.Jobs))
               .ReverseMap();

            CreateMap<Company, ResponseJobCompany>()
              .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
              .ForMember(dest => dest.JobId, opt => opt.MapFrom(src => src.Jobs))
              .ReverseMap();

            //================================================================================

            CreateMap<RequestCreatePost, Post>()
               .ForMember(p => p.JobId, act => act.MapFrom(src => src.JobId))
               .ForMember(p => p.HrId, act => act.MapFrom(src => src.HrId))
               .ForMember(p => p.Title, act => act.MapFrom(src => src.Title))
               .ForMember(p => p.PeriodDate, act => act.MapFrom(src => src.PeriodDate))
               .ForMember(p => p.ExpiredDate, act => act.MapFrom(src => src.ExpiredDate))
               .ForMember(p => p.Location, act => act.MapFrom(src => src.Location))
               .ForMember(p => p.Salary, act => act.MapFrom(src => src.Salary))
               .ForMember(p => p.EmploymentType, act => act.MapFrom(src => src.EmploymentType))
               .ForMember(p => p.Requirements, act => act.MapFrom(src => src.Requirements));


            CreateMap<Post, ResponsePostCompany>()
               .ForMember(p => p.CompanyId, act => act.MapFrom(src => src.CompanyId))
               .ForMember(p => p.NameCompany, act => act.MapFrom(src => src.Company.NameCompany))
               .ForMember(p => p.JobId, act => act.MapFrom(src => src.JobId))
               .ForMember(p => p.HrId, act => act.MapFrom(src => src.HrId))
               .ForMember(p => p.NameSkill, act => act.MapFrom(src => src.Job!.NameSkill))
               .ForMember(p => p.Description, act => act.MapFrom(src => src.Job.Description))
               .ForMember(p => p.Title, act => act.MapFrom(src => src.Title))
               .ForMember(p => p.Salary, act => act.MapFrom(src => src.Salary))
               .ForMember(p => p.PeriodDate, act => act.MapFrom(src => src.PeriodDate))
               .ForMember(p => p.ExpiredDate, act => act.MapFrom(src => src.ExpiredDate))
               .ForMember(p => p.EmploymentType, act => act.MapFrom(src => src.EmploymentType))
               .ForMember(p => p.Requirements, act => act.MapFrom(src => src.Requirements))
               .ForMember(p => p.Location, act => act.MapFrom(src => src.Location))
               .ForMember(p => p.StatusPost, act => act.MapFrom(src => src.Status))
               .ForMember(p => p.hrName, act => act.MapFrom(src => src.Hr.NameHr));

            // .ForMember(p => p.postVersion, act => act.MapFrom(src => src.PostVersions.Select(pv => pv.Version)));

            //ResponeOfCompany-----------------------
            CreateMap<Company, ResponseOfCompany>()
                .ForMember(c => c.AccountId, act => act.MapFrom(src => src.Accountid))
                .ForMember(c => c.CompanyId, act => act.MapFrom(src => src.CompanyId))
                .ForMember(c => c.FirstName, act => act.MapFrom(src => src.Account!.FirstName))
                .ForMember(c => c.LastName, act => act.MapFrom(src => src.Account!.LastName))
                .ForMember(c => c.NameCompany, act => act.MapFrom(src => src.NameCompany))
                .ForMember(c => c.Username, act => act.MapFrom(src => src.Account!.Username))
                .ForMember(c => c.Birthday, act => act.MapFrom(src => src.Account!.Birthday))
                .ForMember(c => c.Email, act => act.MapFrom(src => src.Account!.Email))
                .ForMember(c => c.Address, act => act.MapFrom(src => src.Account!.Address))
                .ForMember(c => c.ContactNumber, act => act.MapFrom(src => src.ContactNumber));

            CreateMap<UpdateRequestCompany, Company>()
                .ForPath(c => c.Account.FirstName, act => act.MapFrom(src => src.firstName))
                .ForPath(c => c.Account.LastName, act => act.MapFrom(src => src.lastName))
                .ForPath(c => c.Account.Email, act => act.MapFrom(src => src.email))
                .ForPath(c => c.Account.Address, act => act.MapFrom(src => src.address))
                .ForMember(c => c.ContactNumber, act => act.MapFrom(src => src.contactNumber))
                .ForMember(c => c.NameCompany, act => act.MapFrom(src => src.nameCompany));






            //   
            //---------------------------------CV--------------------------------------------------



            CreateMap<CvRequest, Cv>()
               .ForMember(p => p.CandidateId, act => act.MapFrom(src => src.CandidateId))
               .ForMember(p => p.Title, act => act.MapFrom(src => src.Title))
               .ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
               ;


            CreateMap<Cv, ResponsePostCv>()
               .ForMember(p => p.CandidateId, act => act.MapFrom(src => src.CandidateId))
               .ForMember(p => p.Title, act => act.MapFrom(src => src.Title))
               .ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
               .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
               .ForMember(p => p.CvId, act => act.MapFrom(src => src.CvId))
               .ForMember(p => p.UrlFile, act => act.MapFrom(src => src.UrlFile))
               .ForMember(p => p.CreationDate, act => act.MapFrom(src => src.CreationDate));




            //-------------------------------------------------------------------------------------



            CreateMap<RequestCreateOperation, Operation>()
               .ForMember(p => p.Date, act => act.MapFrom(src => src.Date))
               .ForMember(p => p.CvId, act => act.MapFrom(src => src.CvId))
               .ForMember(p => p.PostId, act => act.MapFrom(src => src.PostId))
               .ForMember(p => p.HrId, act => act.MapFrom(src => src.HrId));

            CreateMap<Operation, ResponseOperation>()
               .ForMember(p => p.OperationId, act => act.MapFrom(src => src.OperationId))
               .ForMember(p => p.Date, act => act.MapFrom(src => src.Date))
               .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))

               .ForPath(p => p.responseCv, act => act.MapFrom(src => src.Cv))
               .ForPath(p => p.responsePostCompany, act => act.MapFrom(src => src.Post))
            .AfterMap((src, dest) => dest.responsePostCompany.NameSkill = src.Post.Job!.NameSkill)
            .AfterMap((src, dest) => dest.responsePostCompany.Description = src.Post.Job!.Description);


            //--------- RequestUpdateStatusApply --------------------------

            CreateMap<RequestUpdateStatusApply, Operation>()
            //   .ForMember(p => p.OperationId, act => act.MapFrom(src => src.OperationId))
               .ForMember(p => p.Status, act => act.MapFrom(src => src.Status));
            CreateMap<RequestUpdateStatusApply, Post>()
               .ForMember(p => p.Status, act => act.MapFrom(src => src.Status));

            //--------------------------------------------------------------

            CreateMap<RequestLogin, Account>()
                .ForMember(p => p.Username, act => act.MapFrom(src => src.UserName))
                .ForMember(p => p.HashPassword, act => act.MapFrom(src => src.Password));


            //------------------------------------------------------------
            CreateMap<RefreshTokenRequest, RefreshToken>()
                 .ForMember(p => p.Token, act => act.MapFrom(src => src.RefreshToken));

            CreateMap<AccessToken, AuthenResponseMessToken>()
                .ForMember(p => p.Token, act => act.MapFrom(src => src.Token))
                .ForMember(p => p.Expiration, act => act.MapFrom(src => src.ExpirationTicks))
                .ForMember(p => p.RefreshToken, act => act.MapFrom(src => src.RefreshToken.Token));
        }

    }
}
