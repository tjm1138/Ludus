namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table ("StudentBadgeLink")]
    public partial class StudentBadgeLink
    {
        [Key]
        public int Id { get; set; }
        public int BadgeId { get; set; }
        public int StudentId { get; set; }
        public System.DateTime AwardDate { get; set; }
    
        public virtual Badge Badge { get; set; }
        public virtual Student Student { get; set; }
    }
}
