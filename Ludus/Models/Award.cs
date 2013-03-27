namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Award")]
    public class Award
    {
        public Award()
        {
            this.CourseAwardLinks = new HashSet<CourseAwardLink>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<CourseAwardLink> CourseAwardLinks { get; set; }
    }
}
