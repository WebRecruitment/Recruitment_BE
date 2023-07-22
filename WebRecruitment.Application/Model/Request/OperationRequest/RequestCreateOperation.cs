using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRecruitment.Application.Model.Request.OperationRequest
{
    public class RequestCreateOperation
    {
        public RequestCreateOperation() { }

        public RequestCreateOperation(Guid postId, Guid cvId, Guid hrId, DateTime date)
        {
            PostId = postId;
            CvId = cvId;
            HrId = hrId;
            Date = date;
        }

        public Guid PostId { get; set; }
        public Guid CvId { get; set; }
        public Guid HrId { get; set; }
        public DateTime Date { get; set; }
    }
}
