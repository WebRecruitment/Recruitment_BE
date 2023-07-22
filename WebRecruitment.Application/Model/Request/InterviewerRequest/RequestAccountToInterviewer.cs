using System.ComponentModel.DataAnnotations;

namespace WebRecruitment.Application.Model.Request.InterviewerRequest
{
    public class RequestAccountToInterviewer
    {
        public RequestAccountToInterviewer()
        {
        }

        public RequestAccountToInterviewer(Guid? positionId, string username, string hashPassword, string firstName, DateTime date, string lastName, string email, string nameInterviewer)
        {
            PositionId = positionId;
            Username = username;
            HashPassword = hashPassword;
            FirstName = firstName;
            Date = date;
            LastName = lastName;
            Email = email;
            NameInterviewer = nameInterviewer;
        }

        [Required(ErrorMessage = "The PositionId field is required.")]
        public Guid? PositionId { get; set; }

        [Required(ErrorMessage = "The Username field is required.")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "The HashPassword field is required.")]
        public string HashPassword { get; set; } = null!;
        [Required(ErrorMessage = "The First Name field is required.")]
        public string FirstName { get; set; } = null!;
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string NameInterviewer { get; set; } = null!;
     
    }
}
