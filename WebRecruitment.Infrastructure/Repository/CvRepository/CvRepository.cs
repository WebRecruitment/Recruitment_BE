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

        public async Task<Cv> CreatCv(Cv cv)
        {

            await _context.Set<Cv>()!.AddAsync(cv);
            await _context.SaveChangesAsync();
            return cv;

        }

        public async Task DeleteCvAsync(Guid id)
        {
            var deleteCv = _context.Cvs!
                .SingleOrDefault(c => c.CvId == id);
            if (deleteCv != null)
            {
                _context.Cvs!.Remove(deleteCv);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Cv>> getAllCvs()
        {

            var cvs = await _context.Set<Cv>()!.Include(c => c.Candidate).ThenInclude(a => a.Account).ToListAsync();
            if (cvs == null)
            {
                throw new Exception($"{nameof(cvs)} is null");
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
                throw new Exception($"{nameof(cv)} is null");
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
                throw new Exception($"{nameof(cv)} is null");
            }
            return cv;

        }


        public async Task UpdateCvAsync(Guid id, Cv cv)
        {
            if (id == cv.CvId)
            {
                //var updateCv = _mapper.Map<Cv>(cv);
                //_context.Cvs!.Update(updateCv);
                //await _context.SaveChangesAsync();
            }
        }
    }
}
