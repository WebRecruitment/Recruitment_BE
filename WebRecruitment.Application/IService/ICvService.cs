using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRecruitment.Application.Model.Request.CvRequest;
using WebRecruitment.Application.Model.Response.CvResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IService
{
    public interface ICvService
    {
        Task<ResponsePostCv> CreatCv(CvRequest cvRequest);
        Task<Stream> GetName(string name);
        Task<List<ResponsePostCv>> getAllCvs();

    }
}
