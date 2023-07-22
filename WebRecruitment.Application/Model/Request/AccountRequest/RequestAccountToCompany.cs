using System.ComponentModel.DataAnnotations;

namespace WebRecruitment.Application.Model.Request.AccountRequest
{
    public class RequestAccountToCompany
    {
        public RequestAccountToCompany()
        {
        }

        public RequestAccountToCompany(string username, string hashPassword, string firstName, DateTime date, string lastName, string email, string address, int contactNumber, string nameCompany, int phone, string gender)
        {
            Username = username;
            HashPassword = hashPassword;
            FirstName = firstName;
            Date = date;
            LastName = lastName;
            Email = email;
            Address = address;
            ContactNumber = contactNumber;
            NameCompany = nameCompany;
            Phone = phone;
            Gender = gender;
        }

        [Required(ErrorMessage = "The Username field is required.")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "The Password field is required.")]
        public string HashPassword { get; set; } = null!;
        [Required(ErrorMessage = "The First Name field is required.")]
        public string FirstName { get; set; } = null!;
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;
        public int ContactNumber { get; set; }
        public string NameCompany { get; set; } = null!;
        //[Phone]
        public int Phone { get; set; }

        public string Gender { get; set; } = null!;


    }
}
