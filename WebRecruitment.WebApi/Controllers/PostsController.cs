using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.Model.Request.PostRequest;
using WebRecruitment.Application.Model.Response.PostResponse;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.HrRequest;
using WebRecruitment.Application.Common;
using WebRecruitment.Application.Model.Response;

namespace WebRecruitment.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class PostsController : ControllerBase
    {

        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        //[Authorize(Roles = "CANDIDATE")]
        public async Task<ActionResult<IEnumerable<ResponsePostCompany>>> GetAllPost()
        {

            var account = await _postService.GetAllPost();
            return Ok(new
            {
                Success = true,
                Data = account,
            });

        }
        [HttpGet]
        public async Task<ActionResult<ResponsePostCompany>> GetPost(Guid id)
        {

            var post = await _postService.GetPostById(id);
            return post == null ? NotFound() : Ok(post);

        }

        [HttpPost]
        public async Task<ActionResult<ResponsePostCompany>> CreatePostCompany(RequestCreatePost requestCreatePost)
        {

            var response = await _postService.CreatePostCompany(requestCreatePost);
            return response == null ? BadRequest("Khong the create post") : Ok(new
            {
                Success = true,
                Data = response
            });

        }


        [HttpGet]
        public async Task<ActionResult<ResponsePostCompany>> GetPostByLocation(string location)
        {

            var post = await _postService.GetPostByLocation(location);
            return post == null ? BadRequest() : Ok(post);

        }
        [HttpGet]
        public async Task<ActionResult<ResponsePostCompany>> GetPostBySalary(double salary)
        {
            var post = await _postService.GetPostBySalary(salary);
            return post == null ? NotFound() : Ok(post);
        }

        [HttpGet]
        public async Task<ActionResult<ResponsePostCompany>> GetPostByNameSkill(string nameSkill)
        {

            var post = await _postService.GetPostByNameSkill(nameSkill);
            return post == null ? NotFound() : Ok(post);

        }
        [HttpPatch]
        public async Task<ActionResult<ResponsePostCompany>> UpdatePostIdByCompanyId(Guid companyId, Guid postId, [FromBody] RequestUpdateStatusApply requestUpdateStatusApply)
        {
            try
            {
                var response = await _postService.UpdateStatusPostIdByCompanyId(companyId, postId, requestUpdateStatusApply);
                return response == null ? BadRequest() : Ok(new
                {
                    Success = true,
                    Data = response
                });
            }catch (Exception ex)
            {
                return BadRequest( new ErrorMessResponse {
                    Exception = ex,
                    Success = false,
                    Message = ex.Message,
                    Error=404
                });

            }

        }
        [HttpGet]
        public async Task<Pagination<ResponsePostCompany>> GetPaginationPost(int pageIndex = 0, int pageSize = 10)
        {

            var response = await _postService.GetAllPaging(pageIndex, pageSize);
            return response;
        }
    }
}

