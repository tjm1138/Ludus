namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Section")]
    public class Section
    {
        public Section()
        {
            this.Assignments = new HashSet<Assignment>();
            this.Badges = new HashSet<Badge>();
            this.Enrollments = new HashSet<Enrollment>();
            this.Quizs = new HashSet<Quiz>();
        }

        [Key]
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int CourseId { get; set; }
        public string Number { get; set; }
        public int Limit { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Badge> Badges { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Quiz> Quizs { get; set; }
        [ForeignKey("SessionId")]
        public virtual Session Session { get; set; }
    }
}
