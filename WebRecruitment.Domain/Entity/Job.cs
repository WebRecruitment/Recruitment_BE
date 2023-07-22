using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity
{
    public partial class Job
    {
        public Job()
        {
            Posts = new HashSet<Post>();
        }

        public Guid JobId { get; set; }

        public string Status { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string NameSkill { get; set; } = null!;

        public Guid? CompanyId { get; set; }

        [JsonInclude]
        public virtual Company? Company { get; set; }
        [JsonIgnore]

        public virtual ICollection<Post> Posts { get; set; }
    }
}
