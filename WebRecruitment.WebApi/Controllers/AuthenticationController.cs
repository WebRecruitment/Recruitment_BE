using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Request.AuthenRequest;
using WebRecruitment.Application.Model.Response.AuthenResponse;
using WebRecruitment.Infrastructure.Service;

namespace WebRecruitment.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenService _authenService;
        private readonly IEmailService _emailService;

        public AuthenticationController(IAuthenService authenService, IEmailService emailService)
        {
            _authenService = authenService;
            _emailService = emailService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthenResponseMessToken>> Validate(RequestLogin requestLogin)
        {

            var account = await _authenService.CreateAccessTokenAsync(requestLogin);
            return account == null ? BadRequest() : Ok(new
            {
                Success = true,
                Data = account
            });
        }
        [HttpPost("refresh-token")]
        public async Task<ActionResult<AuthenResponseMessToken>> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
                var accessToken = await _authenService.RefreshTokenAsync(refreshTokenRequest.RefreshToken, refreshTokenRequest.UserEmail);
                return accessToken == null ? BadRequest() : Ok(new
                {
                    Success = true,
                    Data = accessToken
                });
        }
        [HttpPost("revoke-token")]
        public IActionResult RevokeToken(RefreshTokenRequest revokeTokenRequest)
        {
            _authenService.RevokeRefreshToken(revokeTokenRequest.RefreshToken, revokeTokenRequest.UserEmail);
            return Ok();
        }

        [HttpPost]
        public async Task SendMailResetPassword(string recipientEmail)
        {
            await _emailService.SendMail(recipientEmail);
        }
    }
}

