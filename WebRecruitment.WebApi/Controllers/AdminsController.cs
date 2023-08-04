using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;

namespace WebRecruitment.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]

        public async Task<ActionResult<ResponseAccountAdmin>> CreateAdminAccount(RequestAccountToAdmin requestAccountToAdmin)
        {

            var response = await _adminService.CreateAccountAdmin(requestAccountToAdmin);
            return response == null ? BadRequest() : Ok(new
            {
                Success = true,
                Data = response
            });

        }
        [HttpPatch]
        [Authorize(Roles = "ADMIN")]

        public async Task<ActionResult<ResponseAccountCompany>> UpdateStatusCompany(Guid adminId, Guid companyId, string status)
        {

            var response = await _adminService.UpdateStatusCompany(adminId, companyId, status);
            return response == null ? BadRequest() : Ok(new
            {
                Success = true,
                Data = response
            });

        }


    }
}
