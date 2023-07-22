using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.IRepository.PostsRepository;


using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums;
using WebRecruitment.Infrastructure.GenericRepository;

namespace WebRecruitment.Infrastructure.Repository.PostsRepository
{
    public class PostsRepository : GenericRepository<Post>, IPost
    {
        public PostsRepository(TuyendungContext context) : base(context)
        {
        }

        public async Task<Post> CreatePostCompany(Post post)
        {
            await _context.Set<Post>()!.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task DeletePostAsync(Guid id)
        {
            var deletePost = _context.Posts.SingleOrDefault(post => post.PostId == id);
            if (deletePost != null)
            {
                _context.Posts.Remove(deletePost);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> GetAllPostAsync()
        {

            var posts = await _context.Set<Post>()!
                .Include(c => c.Company)
                .ThenInclude(j => j.Jobs)
                .Include(j => j.Hr)
                .Include(o => o.Operations)
                .ToListAsync();
            return posts;

        }



        public async Task<Post> GetPostById(Guid postId)
        {

            var post = await _context.Set<Post>()!
             .Include(c => c.Company)
             .Include(j => j.Job)
             .Include(hr => hr.Hr)
             .Include(o => o.Operations)
             .FirstOrDefaultAsync(post => post.PostId == postId);
            if (post == null)
            {
                throw new Exception($"{nameof(postId)} is null" + postId);

            }
            return post;


        }

        public async Task<List<Post>> GetPostByLocation(string location)
        {

            var post = await _context.Set<Post>()!
            .Where(entry => entry.Location.ToLower()
            .Contains(location.ToLower())
       && entry.Status.Equals(POSTENUM.ACCEPT.ToString()))
           .Include(com => com.Company)
           .Include(job => job.Job)
           .Include(hr => hr.Hr)
           .Include(o => o.Operations)
           .ToListAsync();
            if (post == null)
            {
                throw new Exception("location Is Not Exsit");
            }
            return post;



        }

        public async Task<List<Post>> GetPostByNameSkill(string nameSkill)
        {

            var post = await _context.Set<Post>()!
         .Where(entry => entry.Job.NameSkill.ToLower().Contains(nameSkill.ToLower())
         && entry.Status.Equals(POSTENUM.ACCEPT.ToString()))
         .Include(com => com.Company)
         .Include(job => job.Job)
         .Include(hr => hr.Hr)
         .Include(o => o.Operations)
         .ToListAsync();
            if (post == null)
            {
                throw new Exception("Name Skill Is Not Exsit");
            }
            return post;


        }

        public async Task<List<Post>> GetPostBySalary(double salary)
        {

            var post = await _context.Set<Post>()!
                .Where(entry => entry.Salary == salary
                      && entry.Status.Equals(POSTENUM.ACCEPT.ToString()))
                .Include(com => com.Company)
                .Include(job => job.Job)
                .Include(hr => hr.Hr)
                .Include(o => o.Operations)
                .ToListAsync();
            if (post == null)
            {
                throw new Exception("Salary Is Not Exsit");
            }
            return post;

        }


        public async Task<List<Post>> SortPostByStartPost()
        {

            var post = await _context.Set<Post>()!
               .Include(com => com.Company)
               .Include(hr => hr.Hr)
               .Include(job => job.Job)
               .Include(o => o.Operations)
               .ToListAsync();

            post.OrderByDescending(entry => entry.PeriodDate);
            post.Reverse();
           
            return post;


        }


        public async Task<Post> UpdatePostIdCompanyIdWithStatus(Post post)
        {

            _context.Set<Post>()!.Update(post);
            await _context.SaveChangesAsync();
            return post;

        }
    }
}
