using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.IRepository.PositionRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure.GenericRepository;

namespace WebRecruitment.Infrastructure.Repository.PositionRepository
{
    public class PositionRepository : GenericRepository<Position>, IPosition
    {
        public PositionRepository(TuyendungContext context) : base(context)
        {
        }

        public async Task<Position> GetPositionById(Guid positionId)
        {
            var position = await _context.Set<Position>()!.FirstOrDefaultAsync(p => p.PositionId == positionId);
            if (position == null)
            {
                throw new Exception("NOT FOUND POSITION");
            }
            return position;
        }

        public async Task<Position> GetPositionByWId(Guid? positionId)
        {

            var position = await _context.Set<Position>()!.FirstOrDefaultAsync(p => p.PositionId == positionId);
            if (position == null)
            {
                throw new Exception("NOT FOUND POSITION");
            }
            return position;

        }


    }
}
