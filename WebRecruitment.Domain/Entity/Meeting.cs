using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity
{
    public partial class Meeting
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MeetId { get; set; }

        public string LinkMeet { get; set; } = null!;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        
        public Guid OperationId { get; set; }

        public Guid InterviewerId { get; set; }

        public Guid HrId { get; set; }
        [JsonInclude]
        public virtual Hr Hr { get; set; } = null!;
        [JsonInclude]

        public virtual Interviewer Interviewer { get; set; } = null!;
        [JsonInclude]
        public virtual Operation Operation { get; set; } = null!;
    }
}
