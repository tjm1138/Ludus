/*
Section Model - All section-related items derive from this.
Shawn Williams
March 31, 2013
*/

namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    // SQL table Section
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

        // Primary Key
        [Key]
        public int Id { get; set; }

        // Session Id
        [Display(Name = "Session Id"), Required]
        public int SessionId { get; set; }
        
        // Course Id
        [Display(Name = "Course Id"), Required]
        public int CourseId { get; set; }

        // Section Number
        [Display(Name = "Section Number"), Required]
        public string Number { get; set; }

        // Student Limit
        [Display(Name = "Student Limit"), Required]
        public int Limit { get; set; }

        // Section Description
        [Display(Name = "Description"), Required]
        public string Description { get; set; }
        
        // Foreign Key Course Id
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        
        // Foreign Key Session Id
        [ForeignKey("SessionId")]
        public virtual Session Session { get; set; }

        // extends IOCollection Assignments
        public virtual ICollection<Assignment> Assignments { get; set; }

        // extends IOCollection Badges
        public virtual ICollection<Badge> Badges { get; set; }

        // extends IOCollection Enrollments
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        // extends IOCollection Quizs
        public virtual ICollection<Quiz> Quizs { get; set; }
    }
}
