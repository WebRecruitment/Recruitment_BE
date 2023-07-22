using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.Model.Request.JobRequest;
using WebRecruitment.Application.Model.Response.JobResponse;

using WebRecruitment.Application.IRepository.JobRepository;
using WebRecruitment.Application.IService;
using System.Net;

namespace WebRecruitment.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseJobCompany>> PostJob(RequestJobCompany requestJobCompany)
        {

            var response = await _jobService.CreateJobByCompany(requestJobCompany);
            return response == null ? BadRequest() : Ok(new
            {
                Success = true,
                Data = response
            });
        }

        [HttpGet]
        public async Task<ActionResult<ResponseJobCompany>> GetJobByNameSkill(string nameSkill)
        {

            var job = await _jobService.GetJobResponseByNameSkill(nameSkill);
            if (job == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                Success = true,
                Data = job,
            });

        }
        [HttpGet]
        public async Task<ActionResult<ResponseJobCompany>> GetAllJobs()
        {

            var job = await _jobService.GetAllJob();
            if (job == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                Success = true,
                Data = job,
            });

        }
    }
}
