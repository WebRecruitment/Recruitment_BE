using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRecruitment.Application.Model.Response.JobResponse
{
    public class ResponseCompanyJob
    {
        public ResponseCompanyJob() { }
        public ResponseCompanyJob(Guid companyId, ResponseJobCompany job)
        {
            CompanyId = companyId;
            Job = job;
        }

        public Guid CompanyId { get; set; }
        public ResponseJobCompany Job { get; set; }
    }
}
