using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using WebRecruitment.Application.IRepository.CandidateRepository;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;



namespace WebRecruitment.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {

        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN ,COMPANY")]

        public async Task<ActionResult<IEnumerable<ResponseAccountCandidate>>> GetCandidates()
        {

            var candidate = await _candidateService.GetAllCandidate();
            return Ok(new
            {
                Success = true,
                Data = candidate,
            });

        }


        [HttpPost]

        public async Task<ActionResult<ResponseAccountCandidate>> CreateCandidateAccount(RequestAccountToCadidate requestAccountToCandidate)
        {

            var response = await _candidateService.CreateAccountCandidate(requestAccountToCandidate);
            return response == null ? NotFound() : Ok(new
            {
                Success = true,
                Data = response
            });

        }

    }
}
