﻿using WebRecruitment.Application.IGenericRepository;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository.InterviewerRepository
{
    public interface IInterviewer : IGenericRepository<Interviewer>
    {
        Task<List<Interviewer>> GetALLInterviewer();
        Task<Interviewer> CreateAccountInterviewerByPositionCompany(Interviewer interviewer);
        Task<Interviewer> GetInterviewerById(Guid interviewerId);

    }
}