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

        [ForeignKey("FK_Submission_ToEnrollment")]
        public int EnrollmentId { get; set; }

        [ForeignKey("FK_Submission_ToAssignment")]
        public int AssignmentId { get; set; }

        public int Grade { get; set; }
        public string SubmitterComments { get; set; }
        public string ScorerComments { get; set; }
        public Nullable<System.DateTime> SubmissionDate { get; set; }
    
        public virtual Assignment Assignment { get; set; }
        public virtual Enrollment Enrollment { get; set; }
    }
}
