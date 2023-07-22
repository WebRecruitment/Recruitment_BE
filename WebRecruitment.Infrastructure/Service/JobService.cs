using AutoMapper;
using WebRecruitment.Application;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.JobRequest;
using WebRecruitment.Application.Model.Response.JobResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums;

namespace WebRecruitment.Infrastructure.Service
{
    public class JobService : IJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseJobCompany> CreateJobByCompany(RequestJobCompany requestJobCompany)
        {

            var job = _mapper.Map<Job>(requestJobCompany);
            var company = await _unitOfWork.Company.GetByCompanyWId(job.CompanyId);

            if (!company.Status.Equals(COMPANYENUM.ACTIVE.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("STATUS COMPANY Not ACTIVE");
            }

            job.Status = JOBENUM.ACCEPT.ToString();
            var response =  _unitOfWork.Job.Add(job);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ResponseJobCompany>(response);

        }

        public async Task<List<ResponseJobCompany>> GetAllJob()
        {
            var job = await _unitOfWork.Job.GetAllJob();
            return  _mapper.Map<List<ResponseJobCompany>>(job);
        }

        public async Task<ResponseJobCompany> GetJobResponseById(Guid jobId)
        {

            var job = await _unitOfWork.Job.GetJobById(jobId);

            return _mapper.Map<ResponseJobCompany>(job);

        }

        public async Task<List<ResponseJobCompany>> GetJobResponseByNameSkill(string nameSkill)
        {

            var job = await _unitOfWork.Job.GetJobByNameSkill(nameSkill);

            return _mapper.Map<List<ResponseJobCompany>>(job);

        }
    }
}
