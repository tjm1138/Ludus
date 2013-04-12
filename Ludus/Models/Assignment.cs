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

        [Display(Name = "Section Id"), Required]
        public int SectionId { get; set; }

        [Display(Name = "Submission Limit"), Required]
        public int SubmissionLimit { get; set; }

        [Display(Name = "Maximum Grade"), Required]
        public int MaximumGrade { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
