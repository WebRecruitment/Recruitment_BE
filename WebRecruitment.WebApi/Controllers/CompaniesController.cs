using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Request.CompanyRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.Model.Response.JobResponse;

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
        [Authorize(Roles = "ADMIN ,COMPANY")]

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
            try
            {
                var response = await _companyService.GetByCompanyId(id);

                return Ok(new
                {
                    Success = true,
                    Data = response,
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    Success = HttpStatusCode.InternalServerError,
                    Message = "Failed",
                    Error = ex.Message
                });
            }

        }


        [HttpPost]
        public async Task<ActionResult<ResponseAccountCompany>> CreateCompanyAccount(RequestAccountToCompany requestAccountToCompany)
        {

            try
            {
                var response = await _companyService.CreateAccountCompany(requestAccountToCompany);
                return Ok(new
                {
                    Success = HttpStatusCode.OK,
                    Message = "Success",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = HttpStatusCode.InternalServerError,
                    Message = "Failed",
                    Error = ex.Message
                });

            }
        }



        //[HttpDelete]
        //public ActionResult DeleteCompany_ChangeStatus(Guid id)
        //{
        //    _company.ChangeStatus(id);
        //    return Ok(new
        //    {
        //        Success = true,
        //    });
        //}

        [HttpPut]
        [Authorize(Roles = "ADMIN ,COMPANY")]

        public async Task<IActionResult> UpdateCompany(Guid id, UpdateRequestCompany updateRequestCompany)
        {
            try
            {
                if (id == null || updateRequestCompany == null)
                {
                    return BadRequest();
                }
                var response = await _companyService.UpdateCompany(id, updateRequestCompany);
                if (response == null)
                {
                    return BadRequest();
                }

                return Ok(new
                {
                    Success = true,
                    Data = response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

    }
}
