

using WebRecruitment.Application.Model.Request.PostRequest;
using WebRecruitment.Application.Model.Response.PostResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IService
{
    public interface IPositonService
    {
        public Task<List<ResponsePostCompany>> GetAllPost();
        public Task<ResponsePostCompany> GetPostById(Guid postId);
        public Task UpdatePostAsync(Guid id, Post model);
        public Task DeletePostAsync(Guid id);
        public Task<ResponsePostCompany> CreatePostCompany(RequestCreatePost requestCreatePost);


       // public Task<Post> UpdatePostIdCompanyIdWithStatus(Guid postId, Guid companyId);

        public Task<List<ResponsePostCompany>> GetPostByLocation(string location);
        public Task<List<ResponsePostCompany>> GetPostBySalary(double salary);
        public Task<List<ResponsePostCompany>> GetPostByNameSkill(string nameSkill);
        public Task<List<ResponsePostCompany>> SortPostByStartPost();
        public Task UpdateStatusPostAsync(Guid id);
        public Task UpdateStatusOfHr(Guid id);
    }
}
