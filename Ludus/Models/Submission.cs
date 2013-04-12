namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Submission")]
    public class Submission
    {
        [Key]
        public int Id { get; set; }

        public int EnrollmentId { get; set; }
        public int AssignmentId { get; set; }

        public int Grade { get; set; }
        public string SubmitterComments { get; set; }
        public string ScorerComments { get; set; }
        public Nullable<System.DateTime> SubmissionDate { get; set; }

        [ForeignKey("AssignmentId")]
        public virtual Assignment Assignment { get; set; }
        [ForeignKey("EnrollmentId")]
        public virtual Enrollment Enrollment { get; set; }
    }
}
