namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Enrollment")]
    public class Enrollment
    {
        public Enrollment()
        {
            this.Submissions = new HashSet<Submission>();
        }

        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SectionId { get; set; }
        public int Grade { get; set; }
        public bool Active { get; set; }
    
        public virtual Section Section { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
