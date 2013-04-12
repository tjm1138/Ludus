namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("CourseAwardLink")]
    public class CourseAwardLink
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int AwardId { get; set; }
        public System.DateTime Occurred { get; set; }

        [ForeignKey("AwardId")]
        public virtual Award Award { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
