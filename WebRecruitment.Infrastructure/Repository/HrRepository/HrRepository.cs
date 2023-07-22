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
        private readonly IMapper _mapper;
        private readonly ICompany _company;

        public HrRepository(TuyendungContext context) : base(context)
        {
        }


        public async Task<Hr> CreateAccountHRByPositionCompany(Hr hr)
        {

            _context.Accounts.Add(hr.Account);
            _context.Hrs.Add(hr);
            await _context.SaveChangesAsync();
            return hr;

        }

        public async Task<List<Hr>> GetALLHr()
        {
            
                var hr = await _context.Hrs!
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
                throw new Exception($"{nameof(hrId)} is null");
            }
            return hr;

        }

        public async Task<List<Hr>> GetHrByName(string name)
        {

            var hr = _context.Hrs
                .Where(e => e.NameHr.Contains(name))
                .Include(a => a.Account)
                .Include(p => p.Position)
                .Include(c => c.Company)
                .ToList();
            if (hr == null)
            {
                throw new Exception($"{nameof(name)} is null" + name);
            }
            return hr;


        }

        public async Task<List<Hr>> GetHrByStatus(string status)
        {

            var hr = await _context.Hrs
            .Where(e => e.Status.ToUpper().Contains(status.ToUpper()))
            .Include(a => a.Account)
            .Include(p => p.Position)
            .Include(c => c.Company)
            .ToListAsync();
            if (hr == null)
            {
                throw new Exception($"{nameof(status)} is null" + status);
            }
            return hr;

        }



        public async Task SetHrStatus(Guid hrId)
        {

            var hr = await _context.Hrs.SingleOrDefaultAsync(d => d.HrId == hrId);
            if (hr == null)
            {
                throw new Exception($"{nameof(hrId)} is null" + hrId);
            }
            hr.Status = HRENUM.ACTIVE.ToString();
            _context.Hrs!.Update(hr);
            await _context.SaveChangesAsync();
        }


        public async Task SetStatusAccountOfHr(Guid hrId)
        {
            
                var hr = _context.Hrs
                .SingleOrDefault(d => d.HrId == hrId);
                if (hr != null)
                {
                    var accountIdOfHr = hr.Accountid;
                    var updateStatusOfHr = _context.Accounts.SingleOrDefault(d => d.Accountid == accountIdOfHr);
                    if (updateStatusOfHr != null)
                    {
                        updateStatusOfHr.Status = ACCOUNTENUM.ACCEPT.ToString();
                        _context.Accounts.Update(updateStatusOfHr);
                        await _context.SaveChangesAsync();
                    }
                }
            

        }

    }
}
