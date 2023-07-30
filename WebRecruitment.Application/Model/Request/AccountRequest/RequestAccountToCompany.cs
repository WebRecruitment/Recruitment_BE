using System.ComponentModel.DataAnnotations;

namespace WebRecruitment.Application.Model.Request.AccountRequest
{
    public class RequestAccountToCompany
    {
        
     

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
        [Required(ErrorMessage = "The Address field is required.")]

        public string Address { get; set; } = null!;
        [Required(ErrorMessage = "The ContactNumber field is required.")]

        public int ContactNumber { get; set; }
        [Required(ErrorMessage = "The NameCompany field is required.")]

        public string NameCompany { get; set; } = null!;
        [Required(ErrorMessage = "The Phone field is required.")]

        //[Phone]
        public int Phone { get; set; }
        [Required(ErrorMessage = "The Gender field is required.")]


        public string Gender { get; set; } = null!;


    }
}
