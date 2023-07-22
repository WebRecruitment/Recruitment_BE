using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.MeetingRepository
{
    public interface IMeeting
    {
        Task<Meeting> CreateMeetingByHrId(RequestAccountToCompany requestAccountToCompany);
    }
}
