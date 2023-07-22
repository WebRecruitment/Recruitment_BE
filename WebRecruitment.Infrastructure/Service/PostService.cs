using AutoMapper;
using Newtonsoft.Json;
using System.Text;
using WebRecruitment.Application;
using WebRecruitment.Application.Common;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.HrRequest;
using WebRecruitment.Application.Model.Request.PostRequest;
using WebRecruitment.Application.Model.Response.PostResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums;

namespace WebRecruitment.Infrastructure.Service
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponsePostCompany> CreatePostCompany(RequestCreatePost requestCreatePost)
        {

            var post = _mapper.Map<Post>(requestCreatePost);
            post.Requirements= $"<div>{requestCreatePost.Requirements}</div>";
            var job = await _unitOfWork.Job.GetJobById(post.JobId);

            if (!job.Status.Equals(JOBENUM.ACCEPT.ToString()))
            {
                throw new Exception("Requirement Company Accept Job ID ACCEPT");
            }
            var hr = await _unitOfWork.Hr.GetHrById(post.HrId);

            if (!hr.Status.Equals(HRENUM.ACTIVE.ToString()) ||
             !hr.Account.Status.Equals(ACCOUNTENUM.ACCEPT.ToString()))
            {
                throw new Exception("Required Company Access HR Status ACTIVE " +
                    "|| Required Admin Accept HRAccount Status ACCEPT");
            }
            //job.CompanyId = post.CompanyId;
            post.CompanyId = job.Company!.CompanyId;
            var company = await _unitOfWork.Company.GetByCompanyId(post.CompanyId);

            if (!company.CompanyId.Equals(hr.CompanyId))
            {
                throw new Exception("Company NOT MATCH JOB AND HR");
            }
            post.Status = POSTENUM.REQUESTCOMPANY.ToString();
            await _unitOfWork.Post.CreatePostCompany(post);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ResponsePostCompany>(post);
        }




        public Task DeletePostAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination<ResponsePostCompany>> GetAllPaging(int pageIndex = 0, int pageSize = 10)
        {
            var postPaging = await _unitOfWork.Post.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<ResponsePostCompany>>(postPaging);
            return result;

        }

        public async Task<List<ResponsePostCompany>> GetAllPost()
        {

            var post = await _unitOfWork.Post.GetAllPostAsync();
            //foreach (var j in post)
            //{
            //    j.Title = FormatStringWithLineBreak(j.Title);
            //}
            return _mapper.Map<List<ResponsePostCompany>>(post);


        }

        public async Task<ResponsePostCompany> GetPostById(Guid postId)
        {

            var post = await _unitOfWork.Post.GetPostById(postId);
            return _mapper.Map<ResponsePostCompany>(post);

        }

        public async Task<List<ResponsePostCompany>> GetPostByLocation(string location)
        {

            var post = await _unitOfWork.Post.GetPostByLocation(location);
            return _mapper.Map<List<ResponsePostCompany>>(post);

        }

        public async Task<List<ResponsePostCompany>> GetPostByNameSkill(string nameSkill)
        {

            var post = await _unitOfWork.Post.GetPostByNameSkill(nameSkill);
            return _mapper.Map<List<ResponsePostCompany>>(post);

        }

        public async Task<List<ResponsePostCompany>> GetPostBySalary(double salary)
        {

            var post = await _unitOfWork.Post.GetPostBySalary(salary);
            return _mapper.Map<List<ResponsePostCompany>>(post);

        }

        public Task<List<ResponsePostCompany>> SortPostByStartPost()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponsePostCompany> UpdateStatusPostIdByCompanyId(Guid companyId, Guid postId, RequestUpdateStatusApply requestUpdateStatusApply)
        {
            var company = await _unitOfWork.Company.GetByCompanyId(companyId);

            if (company.Status != COMPANYENUM.ACTIVE.ToString())
            {
                throw new Exception("STATUS COMPANY NOT ACTIVE ");
            }
            var request = await _unitOfWork.Post.GetPostById(postId);

            if (company.CompanyId != request.CompanyId)
            {
                throw new Exception("STATUS COMPANY NOT ACTIVE ");
            }

            var post = _mapper.Map(requestUpdateStatusApply, request);
            _unitOfWork.Post.Update(post);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ResponsePostCompany>(post);


        }
    }
}

