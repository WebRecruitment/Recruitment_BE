using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Request.CompanyRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.Model.Response.JobResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {

        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet]
        //[Authorize(Roles = "ADMIN ,COMPANY")]

        public async Task<ActionResult<IEnumerable<ResponseAccountCompany>>> GetCompanies()
        {

            var response = await _companyService.GetALLCompany();

            return Ok(new
            {
                Success = true,
                Data = response,
            });

        }

        [HttpGet]
        [Authorize(Roles = "ADMIN ,COMPANY")]

        public async Task<ActionResult<ResponseAccountCompany>> GetCompany(Guid id)
        {

            var response = await _companyService.GetByCompanyId(id);

            return Ok(new
            {
                Success = true,
                Data = response,
            });


        }


        [HttpPost]
        public async Task<ActionResult<ResponseAccountCompany>> CreateCompanyAccount(RequestAccountToCompany requestAccountToCompany)
        {


            var response = await _companyService.CreateAccountCompany(requestAccountToCompany);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });

        }



        [HttpPut]
        [Authorize(Roles = "ADMIN ,COMPANY")]

        public async Task<IActionResult> UpdateCompany(Guid id, UpdateRequestCompany updateRequestCompany)
        {
            var response = await _companyService.UpdateCompany(id, updateRequestCompany);
            return response == null ? BadRequest() : Ok(new
            {
                Success = true,
                Data = response
            });

        }

        [HttpGet]
        [Authorize(Roles = "ADMIN ,COMPANY")]

        public async Task<ActionResult<ResponseCompanyJob>> GetJobCompany(Guid companyId)
        {

            var response = await _companyService.GetJobResponseByCompanyId(companyId);

            return Ok(new
            {
                Success = true,
                Data = response,
            });
        }
        [HttpPatch]
        public async Task<ActionResult<ResponseAccountInterviewer>> UpdateStatusInterviewer(Guid inteviewerId, Guid companyId, string status)
        {

            var response = await _companyService.UpdateStatusInterview(inteviewerId, companyId, status);
            return response == null ? BadRequest() : Ok(new
            {
                Success = true,
                Data = response
            });
        }
        [HttpPatch]
        public async Task<ActionResult<ResponseAccountHr>> UpdateStatusHr(Guid hrId, Guid companyId, string status)
        {


            var response = await _companyService.UpdateStatusHr(hrId, companyId, status);
            return response == null ? BadRequest() : Ok(new
            {
                Success = true,
                Data = response
            });
        }
    }
}
