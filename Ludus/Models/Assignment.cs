/*
Assignment Model - All Assignment items derive from this.
Shawn Williams
March 31, 2013
*/

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

        // The section id
        public int SectionId { get; set; }
        // The submission limit
        [Display(Name = "Submission Limit"), Required]
        public int SubmissionLimit { get; set; }

        // The maximum grade
        [Display(Name = "Maximum Grade"), Required]
        public int MaximumGrade { get; set; }

        // Makes an assignment Active
        [Display(Name = "Active")]
        public bool Active { get; set; }

        // Foreign key
        [ForeignKey("SectionId")]
        
        // extends to Section
        public virtual Section Section { get; set; }
        
        // extends to Submissions
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
