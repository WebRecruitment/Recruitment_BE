using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity
{
    public partial class Position
    {
        public Position()
        {
            Hrs = new HashSet<Hr>();
            Interviewers = new HashSet<Interviewer>();
        }

        public Guid PositionId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; } = null!;
        public string NamePosition { get; set; } = null!;
        public Guid CompanyId { get; set; }
        [JsonInclude]

        public virtual Company Company { get; set; } = null!;
        [JsonInclude]
        public virtual ICollection<Hr> Hrs { get; set; }
        [JsonInclude]

        public virtual ICollection<Interviewer> Interviewers { get; set; }
    }
}
