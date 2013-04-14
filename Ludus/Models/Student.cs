/*
Student Model - All student-related items derive from this.
Shawn Williams
March 31, 2013
*/

namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    // SQL table Student
    [Table("Student")]
    public class Student
    {
        public Student()
        {
            this.Enrollments = new HashSet<Enrollment>();
            this.StudentBadgeLinks = new HashSet<StudentBadgeLink>();
        }

        // Primary Key
        [Key]
        public int Id { get; set; }

        // User Id
        [Display(Name = "User Id")]
        [Required]
        public int UserId { get; set; }

        // Session Id
        [Display(Name = "Session Id")]
        [Required]
        public int SessionId { get; set; }

        // Foreign Key Session Id
        [ForeignKey("SessionId")]
        public virtual Session Session { get; set; }
        
        // Foreign Key User Id
        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile { get; set; }

        // extends ICollection Enrollments
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        // extends ICollection StudentBadgeLinks
        public virtual ICollection<StudentBadgeLink> StudentBadgeLinks { get; set; }
    }
}
