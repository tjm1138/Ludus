namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Assignment")]
    public class Assignment : CalendarBase
    {
        public Assignment()
        {
            this.Submissions = new HashSet<Submission>();
        }

        public int SectionId { get; set; }
        public int SubmissionLimit { get; set; }
        public int MaximumGrade { get; set; }
        public bool Active { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
