namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("CourseItemLink")]
    public class CourseItemLink
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int ItemId { get; set; }
        public System.DateTime Occurred { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
    }
}
