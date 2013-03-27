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
        public int UserId { get; set; }
        public int SessionId { get; set; }
    
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual Session Session { get; set; }
        public virtual ICollection<StudentBadgeLink> StudentBadgeLinks { get; set; }
    }
}
