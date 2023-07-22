using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebRecruitment.Application.Model.Response.PostResponse
{
    public class ResponsePostGetAll
    {

        [DataMember]
        public Guid? JobId { get; set; }
        public Guid? HrId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime StartPost { get; set; }
        public DateTime EndPost { get; set; }

        public string Location { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Salary { get; set; }
        public string NameSkill { get; set; } = null!;
        public DateTime ExpiredDate { get; set; }
    }
}
