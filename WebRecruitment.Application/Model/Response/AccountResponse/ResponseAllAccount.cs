using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRecruitment.Application.Model.Response.AccountResponse
{
    public class ResponseAllAccount
    {
        

        public Guid? AdminId { get; set; }
        public Guid CandidateId { get; set; }
        public Guid CompanyId { get; set; }

        public Guid AccountId { get; set; }
        public string Username { get; set; }
        public string HashPassword { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Email { get; set; } = null!;
        public int Phone { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Bio { get; set; }
        public string Language { get; set; }
        public string Nationality { get; set; }
   

    }
}
