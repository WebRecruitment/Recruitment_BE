using WebRecruitment.Application.IGenericRepository;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.PositionRepository
{
    public interface IPosition :IGenericRepository<Position>
    {
        Task<Position> GetPositionById(Guid? positionId);
    }
}
