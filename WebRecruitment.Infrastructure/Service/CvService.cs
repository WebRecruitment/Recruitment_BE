using AutoMapper;
using Azure.Storage.Blobs;
using WebRecruitment.Application;
using WebRecruitment.Application.Common;
using WebRecruitment.Application.IService;
using WebRecruitment.Application.Model.Request.CvRequest;
using WebRecruitment.Application.Model.Response.CvResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums;

namespace WebRecruitment.Infrastructure.Service
{
    public class CvService : ICvService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly AppConfiguration _appConfiguration;

        public CvService(IMapper mapper, IUnitOfWork unitOfWork, BlobServiceClient blobServiceClient, AppConfiguration appConfiguration)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _blobServiceClient = blobServiceClient;
            _appConfiguration = appConfiguration;
        }

        public async Task<ResponsePostCv> CreatCv(CvRequest cvRequest)
        {

            var cv = _mapper.Map<Cv>(cvRequest);

            var candidate = await _unitOfWork.Candidate.CheckCandidateIdByCv(cv);

            // Take Container Name
            var containerInstance = _blobServiceClient.GetBlobContainerClient(_appConfiguration.ContainerName);

            // Open a stream for the file we want to upload
            var blogInstance = containerInstance.GetBlobClient(cvRequest.UrlFile.FileName);

            // Save File In Azure 
            await blogInstance.UploadAsync(cvRequest.UrlFile.OpenReadStream());

            // Set DB with URI
            cv.Status = CVENUM.ACTIVE.ToString();
            cv.CreationDate = DateTime.Now;
            cv.UrlFile = blogInstance.Uri.AbsoluteUri;

            var response =  _unitOfWork.Cv.Add(cv);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ResponsePostCv>(response);


        }

        public async Task<List<ResponsePostCv>> getAllCvs()
        {

            return _mapper.Map<List<ResponsePostCv>>(await _unitOfWork.Cv.getAllCvs());

        }

        public async Task<Stream> GetName(string name)
        {
            // Take Container Name
            var containerInstance = _blobServiceClient.GetBlobContainerClient(_appConfiguration.ContainerName);
            // Open a stream for the file we want to upload
            var blogInstance = containerInstance.GetBlobClient(name);

            // Save File In Azure 
            var download = await blogInstance.DownloadAsync();
            return download.Value.Content;

        }
    }
}
