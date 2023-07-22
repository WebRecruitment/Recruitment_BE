using AutoMapper;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Application.IRepository.MeetingRepository;

namespace WebRecruitment.Infrastructure.Repository.MeetingRepository
{
    public class MeetingRepository : IMeeting
    {
        private readonly TuyendungContext _context;
        private readonly IMapper _mapper;

        public MeetingRepository(TuyendungContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<Meeting> CreateAccountCompany(RequestAccountToCompany requestAccountToCompany)
        {
            throw new NotImplementedException();
        }

        public Task<Meeting> CreateMeetingByHrId(RequestAccountToCompany requestAccountToCompany)
        {
            throw new NotImplementedException();
        }
    }
}
