using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity
{
    public partial class Post
    {
        public Post()
        {
            Operations = new HashSet<Operation>();
            PostVersions = new HashSet<PostVersion>();
        }

        public Guid PostId { get; set; }
        public string Status { get; set; } = null!;

        /// <summary>
        public string Title { get; set; } = null!;

        public DateTime PeriodDate { get; set; }

        public DateTime ExpiredDate { get; set; }

        public string Location { get; set; } = null!;

        public double Salary { get; set; }

        public string EmploymentType { get; set; } = null!;

        public string Requirements { get; set; } = null!;

        /// </summary>

        public Guid CompanyId { get; set; }
        public Guid JobId { get; set; }
        public Guid HrId { get; set; }
        [JsonInclude]

        public virtual Company Company { get; set; } = null!;
        [JsonInclude]
        public virtual Hr Hr { get; set; } = null!;
        [JsonInclude]
        public virtual Job Job { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Operation> Operations { get; set; }
        [JsonIgnore]
        public virtual ICollection<PostVersion> PostVersions { get; set; }
    }
}
