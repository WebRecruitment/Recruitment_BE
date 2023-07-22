using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRecruitment.Application;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.OperationRequest;
using WebRecruitment.Application.Model.Response.OperationResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums;

namespace WebRecruitment.Infrastructure.Service
{
    public class OperationService : IOperationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OperationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseOperation> CreateOperationCompany(RequestCreateOperation requestCreateOperation)
        {

            var operation = _mapper.Map<Operation>(requestCreateOperation);

            var post = await _unitOfWork.Post.GetPostById(operation.PostId);

            if (post.Status != POSTENUM.ACCEPT.ToString())
            {
                throw new Exception("Require Company set Status Accept Post");
            }

            operation.CompanyId = post.CompanyId;
            var company = await _unitOfWork.Company.GetByCompanyId(operation.CompanyId);
            var hr = await _unitOfWork.Hr.GetHrById(operation.HrId);

            if (company.CompanyId != hr.CompanyId)
            {
                throw new Exception("Hr and Post don't the Same Company");
            }

            var cv = await _unitOfWork.Cv.GetByCvWId(operation.CvId);

            if (cv.Status != CVENUM.ACTIVE.ToString())
            {
                throw new Exception("Status Cv not ACTIVE");
            }

            operation.Status = APPLYENUM.REQUEST.ToString();

            await _unitOfWork.Apply.CheckCvIdExistPost(operation, post);

            var response = _unitOfWork.Apply.Add(operation);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ResponseOperation>(response);


        }

        public async Task<List<ResponseOperation>> GetAllOperation()
        {

            var response = await _unitOfWork.Apply.GetAllOperation();
            return _mapper.Map<List<ResponseOperation>>(response);


        }

        public async Task<ResponseOperation> GetByOperationId(Guid operationId)
        {

            var response = await _unitOfWork.Apply.GetByOperationId(operationId);
            return _mapper.Map<ResponseOperation>(response);

        }

    }
}
