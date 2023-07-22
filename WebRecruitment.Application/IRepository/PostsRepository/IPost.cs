
using WebRecruitment.Application.IGenericRepository;
using WebRecruitment.Application.Model.Request.PostRequest;
using WebRecruitment.Application.Model.Response.PostResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.PostsRepository
{
    public interface IPost : IGenericRepository<Post>
    {
        public Task<List<Post>> GetAllPostAsync();
        public Task<Post> GetPostById(Guid postId);
   //     public Task UpdatePostAsync(Guid id, Post model);

        public Task<List<Post>> GetPostByLocation(string location);
        public Task<List<Post>> GetPostBySalary(double salary);
        public Task<List<Post>> GetPostByNameSkill(string nameSkill);
        public Task<List<Post>> SortPostByStartPost();



    }
}
