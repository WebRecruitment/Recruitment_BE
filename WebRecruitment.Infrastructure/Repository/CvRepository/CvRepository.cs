using AutoMapper;
using Azure.Core;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.Model.Request.CvRequest;
using WebRecruitment.Application.Model.Response.CvResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums;
using WebRecruitment.Application.IRepository.CvRepository;
using WebRecruitment.Infrastructure.GenericRepository;

namespace WebRecruitment.Infrastructure.Repository.CvRepository
{
    public class CvRepository : GenericRepository<Cv>, ICv
    {
        public CvRepository(TuyendungContext context) : base(context)
        {
        }

        public async Task<List<Cv>> getAllCvs()
        {

            var cvs = await _context.Set<Cv>()!.Include(c => c.Candidate).ThenInclude(a => a.Account).ToListAsync();
            if (cvs == null)
            {
                throw new Exception("CV IS NULL");
            }
            return cvs;
        }

        public async Task<Cv> GetByCvId(Guid cVId)
        {

            var cv = await _context.Cvs!
            .Include(c => c.Candidate)
            .Include(c => c.Operations)
            .FirstOrDefaultAsync(c => c.CvId == cVId);
            if (cv == null)
            {
                throw new Exception("CV IS NULL");
            }
            return cv;

        }

        public async Task<Cv> GetByCvWId(Guid? cVId)
        {

            var cv = await _context.Cvs!
             .Include(c => c.Candidate)
             .Include(c => c.Operations)
             .FirstOrDefaultAsync(c => c.CvId == cVId);
            if (cv == null)
            {
                throw new Exception("CV IS NULL");
            }
            return cv;

        }
      
    }
}
