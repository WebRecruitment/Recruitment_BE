using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRecruitment.Application.Model.Request.PostRequest
{
    public class RequestCreatePost
    {

        public Guid JobId { get; set; }

        public Guid HrId { get; set; }

        public string Title { get; set; } = null!;

        public DateTime PeriodDate { get; set; }

        public DateTime ExpiredDate { get; set; }

        public string Location { get; set; } = null!;

        public double Salary { get; set; }

        public string EmploymentType { get; set; } = null!;

        public string Requirements { get; set; } = null!;

    }
}
