namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Student")]
    public class Student
    {
        public Student()
        {
            this.Enrollments = new HashSet<Enrollment>();
            this.StudentBadgeLinks = new HashSet<StudentBadgeLink>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "User Id")]
        [Required]
        public int UserId { get; set; }

        [Display(Name = "Session Id")]
        [Required]
        public int SessionId { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        [ForeignKey("SessionId")]
        public virtual Session Session { get; set; }
        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<StudentBadgeLink> StudentBadgeLinks { get; set; }
    }
}
