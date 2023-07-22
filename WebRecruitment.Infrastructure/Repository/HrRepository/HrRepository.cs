using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.IRepository.CompanyRepository;
using WebRecruitment.Application.IRepository.HRRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums;
using WebRecruitment.Infrastructure.GenericRepository;

namespace WebRecruitment.Infrastructure.Repository.HrRepository
{
    public class HrRepository : GenericRepository<Hr>, IHR
    {
      

        public HrRepository(TuyendungContext context) : base(context)
        {
        }


  

        public async Task<List<Hr>> GetALLHr()
        {
            
                var hr = await _context.Set<Hr>()
                .Include(a => a.Account)
                .Include(p => p.Position)
                .Include(p => p.Posts)
                .Include(c => c.Company)
                .Include(m => m.Meetings)
                .Include(o => o.Operations)
                .ToListAsync();
                return hr;
            
        }

        public async Task<Hr> GetHrById(Guid hrId)
        {

            var hr = await _context.Hrs!.Include(a => a.Account)
            .Include(p => p.Position)
            .Include(c => c.Company)
            .Include(p => p.Posts)
            .Include(m => m.Meetings)
            .Include(o => o.Operations)
            .FirstOrDefaultAsync(s => s.HrId == hrId);
            if (hr == null)
            {
                throw new Exception("NOT FOUND HR");
            }

            return hr;

        }

        public async Task<List<Hr>> GetHrByName(string name)
        {

            var hr = _context.Set<Hr>()
                .Where(e => e.NameHr.Contains(name))
                .Include(a => a.Account)
                .Include(p => p.Position)
                .Include(c => c.Company)
                .ToList();
            if (hr == null)
            {
                throw new Exception("NOT FOUND HR");
            }

            return hr;


        }

        public async Task<List<Hr>> GetHrByStatus(string status)
        {

            var hr = await _context.Set<Hr>()
            .Where(e => e.Status.ToUpper().Contains(status.ToUpper()))
            .Include(a => a.Account)
            .Include(p => p.Position)
            .Include(c => c.Company)
            .ToListAsync();
           
            return hr;

        }

    }
}
