using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRecruitment.Application.Common;
using WebRecruitment.Application.Model.Request.HrRequest;
using WebRecruitment.Application.Model.Request.PostRequest;
using WebRecruitment.Application.Model.Response.OperationResponse;
using WebRecruitment.Application.Model.Response.PostResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IService
{
    public interface IPostService
    {
        Task<ResponsePostCompany> UpdateStatusPostIdByCompanyId(Guid companyId, Guid postId, RequestUpdateStatusApply requestUpdateStatusApply);

        public Task<List<ResponsePostCompany>> GetAllPost();
        public Task<ResponsePostCompany> GetPostById(Guid postId);
        public Task DeletePostAsync(Guid id);
        public Task<ResponsePostCompany> CreatePostCompany(RequestCreatePost requestCreatePost);

        public Task<Pagination<ResponsePostCompany>> GetAllPaging(int pageIndex = 0, int pageSize = 10);
        public Task<List<ResponsePostCompany>> GetPostByLocation(string location);
        public Task<List<ResponsePostCompany>> GetPostBySalary(double salary);
        public Task<List<ResponsePostCompany>> GetPostByNameSkill(string nameSkill);
        public Task<List<ResponsePostCompany>> SortPostByStartPost();
    }
}
