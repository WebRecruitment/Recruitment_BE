using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebRecruitment.Application.Model.Request.HrRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Response.OperationResponse;
using Microsoft.AspNetCore.Authorization;

namespace WebRecruitment.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HrsController : ControllerBase
    {
        private readonly IHrService _hrService;
        public HrsController(IHrService hrService)
        {
            _hrService = hrService;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,COMPANY")]

        public async Task<ActionResult<IEnumerable<ResponseAccountHr>>> GetHrs()
        {

            var response = await _hrService.GetALLHr();

            return Ok(new
            {
                Success = true,
                Data = response,
            });

        }
        [HttpGet]
        [Authorize(Roles = "COMPANY")]
        public async Task<ActionResult<ResponseAccountHr>> GetHrById(Guid id)
        {

            var hr = await _hrService.GetHrById(id);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = hr
            });


        }
        [HttpPost]
        public async Task<ActionResult<ResponseAccountHr>> CreateHrAccountCompany(RequestAccountToHr requestAccountToHr)
        {
            try
            {
                var response = await _hrService.CreateAccountHRByPositionCompany(requestAccountToHr);
                return response == null ? NotFound() : Ok(new
                {
                    Success = true,
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

        [HttpGet]
        [Authorize(Roles = "ADMIN,COMPANY")]

        public async Task<ActionResult<IEnumerable<ResponseAccountHr>>> GetALLHrByCompanyId(Guid companyId)
        {

            var response = await _hrService.GetALLHrByCompanyId(companyId);

            return Ok(new
            {
                Success = true,
                Data = response,
            });

        }
        [HttpGet]
        public async Task<ActionResult<ResponseAccountHr>> GetHrName(string name)
        {
            try
            {
                var hr = await _hrService.GetHrByName(name);
                if (hr == null)
                {
                    return NotFound();
                }
                return Ok(new
                {
                    Success = true,
                    Data = hr,
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
        [HttpGet]
        public async Task<ActionResult<ResponseAccountHr>> GetHrStatus(string status)
        {

            var hr = await _hrService.GetHrByStatus(status);
            if (hr == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                Success = true,
                Data = hr,
            });

        }


        [HttpPatch]
        public async Task<ActionResult<ResponseOperation>> UpdateStatusApplyIdByHrId(Guid hrId, Guid operationId, string status)
        {

            var hr = await _hrService.UpdateStatusApplyIdByHrId(hrId, operationId, status);
            return Ok(new
            {
                Success = true,
                Data = hr
            }
            );

        }
    }
}

