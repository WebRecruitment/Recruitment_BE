using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRecruitment.Application.Model.Response.CompanyResponse
{
    public class ResponseOfCompany
    {
        public Guid AccountId { get; set; }
        public Guid CompanyId { get; set; }
        public string NameCompany { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int ContactNumber { get; set; }

    }
}
