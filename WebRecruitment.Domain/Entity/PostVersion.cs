using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity

{
    public partial class PostVersion
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Version { get; set; }

        public Guid PostId { get; set; }

        public float numberVersion { get; set; }
        [JsonInclude]

        public virtual Post Post { get; set; } = null!;
    }
}
