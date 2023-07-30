using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.AccountRequest;
using Microsoft.AspNetCore.Authorization;

namespace WebRecruitment.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN" )]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<ResponseAllAccount>>> GetAccounts()
        {

            var account = await _accountService.GetResponseAllAccounts();
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = account
            });

        }
        [HttpGet]
        [Authorize(Roles = "ADMIN")]

        public async Task<ActionResult<ResponseAllAccount>> GetAccountsById(Guid id)
        {

            var account = await _accountService.GetAccountById(id);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = account
            });

        }

        [HttpPost]
        public async Task<ActionResult<ResponseAllAccount>> ResetPassword([FromForm] string token, [FromForm] ResetPasswordRequest resetPasswordRequest)
        {
            var response = await _accountService.ResetPassword(token, resetPasswordRequest);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }
        [HttpPatch]
        public async Task<ActionResult<ResponseAllAccount>> ChangeStatusAccount([FromForm] Guid accountId, [FromForm] Guid adminId, [FromForm] string status)
        {
            var response = await _accountService.UpdateAccountStatus(accountId, adminId, status);
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = response
            });
        }

    }
}
