namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Assignment")]
    public class Assignment
    {
        public Assignment()
        {
            this.Submissions = new HashSet<Submission>();
        }

        [Key]
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Due { get; set; }
        public int SubmissionLimit { get; set; }
        public int MaximumGrade { get; set; }
        public bool Active { get; set; }
    
        public virtual Section Section { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
