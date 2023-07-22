using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.CvRequest;
using WebRecruitment.Application.Model.Response.CvResponse;

namespace WebRecruitment.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CvsController : ControllerBase
    {
        private readonly ICvService _cvService;

        public CvsController(ICvService cvService)
        {
            _cvService = cvService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsePostCv>>> GetCvs()
        {

            var cvs = await _cvService.getAllCvs();
            return Ok(new
            {
                Success = true,
                Data = cvs,
            });

        }

        [HttpGet]
        public async Task<IActionResult> GetCvByNames(string name)
        {

            var cvs = await _cvService.GetName(name);

            string fileType = "pdf";
            if (fileType.Contains("png"))
            {
                fileType = "png";
            }
            return File(cvs, $"image/{fileType}");

        }

        [HttpPost]
        public async Task<ActionResult<ResponsePostCv>> CreateCandidateCv([FromForm] CvRequest cvRequest)
        {
            
                var response = await _cvService.CreatCv(cvRequest);
                return response == null ? NotFound() : Ok(new
                {
                    Success = true,
                    Data = response
                });
            
        }

    }
}
