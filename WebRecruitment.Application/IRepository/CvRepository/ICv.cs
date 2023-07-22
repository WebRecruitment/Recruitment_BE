using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRecruitment.Application.IGenericRepository;
using WebRecruitment.Application.Model.Request.CvRequest;
using WebRecruitment.Application.Model.Response.CvResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.CvRepository
{
    public interface ICv : IGenericRepository<Cv>
    {
        Task<List<Cv>> getAllCvs();
        Task<Cv> GetByCvId(Guid cVId);
        Task<Cv> GetByCvWId(Guid? cVId);

    }
}
