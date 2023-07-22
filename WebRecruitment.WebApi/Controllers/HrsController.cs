using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebRecruitment.Application.Model.Request.HrRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Response.OperationResponse;

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
        public async Task<ActionResult<ResponseAccountHr>> GetHr(Guid id)
        {
            try
            {
                var hr = await _hrService.GetHrById(id);
                return Ok(new
                {
                    Success = HttpStatusCode.OK,
                    Message = "Success",
                    Data = hr
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



        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ResponseAccountHr>>> GetSortHrByDate()
        //{
        //    try
        //    {
        //        var response = await _hR.SortHrByDateDesc();

        //        return Ok(new
        //        {
        //            Success = true,
        //            Data = response,
        //        });
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}
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
        public async Task<ActionResult<ResponseOperation>> UpdateStatusApplyIdByHrId(Guid hrId, Guid operationId, RequestUpdateStatusApply requestUpdateStatusApply)
        {

            var hr = await _hrService.UpdateStatusApplyIdByHrId(hrId, operationId, requestUpdateStatusApply);
            return Ok(new
            {
                Success = true,
                Data = hr
            }
            );

        }
    }
}

