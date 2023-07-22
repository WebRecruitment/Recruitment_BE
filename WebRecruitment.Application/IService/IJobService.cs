using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRecruitment.Application.Model.Request.JobRequest;
using WebRecruitment.Application.Model.Response.JobResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IService
{
    public interface IJobService
    {
        Task<ResponseJobCompany> CreateJobByCompany(RequestJobCompany requestJobCompany);
        Task<ResponseJobCompany> GetJobResponseById(Guid jobId);
        Task<List<ResponseJobCompany>> GetJobResponseByNameSkill(string nameSkill);
        Task<List<ResponseJobCompany>> GetAllJob();

    }
}
