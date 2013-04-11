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

        [Display(Name = "Session Id"), Required]
        public int SessionId { get; set; }
        
        [Display(Name = "Course Id"), Required]
        public int CourseId { get; set; }

        [Display(Name = "Section Number"), Required]
        public string Number { get; set; }

        [Display(Name = "Student Limit"), Required]
        public int Limit { get; set; }

        [Display(Name = "Description"), Required]
        public string Description { get; set; }
    
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Badge> Badges { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Quiz> Quizs { get; set; }
        public virtual Session Session { get; set; }
    }
}
