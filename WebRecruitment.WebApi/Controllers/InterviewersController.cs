using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.Model.Request.InterviewerRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;

using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Response.OperationResponse;
using WebRecruitment.Application.Model.Request.HrRequest;
using System.Net;

namespace WebRecruitment.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InterviewersController : ControllerBase
    {
        private readonly IInterviewerService _interviewerService;

        public InterviewersController(IInterviewerService interviewerService)
        {
            _interviewerService = interviewerService;
        }



        // GET: api/Interviewers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseAccountInterviewer>>> GetInterviewers()
        {

            var response = await _interviewerService.GetALLInterviewer();
            return Ok(new
            {
                Success = true,
                Data = response,
            });

        }


        [HttpPost]
        public async Task<ActionResult<ResponseAccountInterviewer>> CreateInterviewAccountCompany(RequestAccountToInterviewer requestAccountToInterviewer)
        {
            try
            {
                var response = await _interviewerService.CreateAccountInterviewerByPositionCompany(requestAccountToInterviewer);
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


        [HttpPatch]
        public async Task<ActionResult<ResponseOperation>> UpdateStatusApplyIdByInterviewerId(Guid interviewerId,  Guid operationId, string status)
        {

            var response = await _interviewerService.UpdateStatusApplyIdByInterviewerId(interviewerId, operationId, status);
            return Ok(new
            {
                Success = true,
                Data = response
            }
            );
        }

    }
}
