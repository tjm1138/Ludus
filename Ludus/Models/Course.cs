/*
Course Model - All course-related items derive from this.
Shawn Williams
March 31, 2013
*/

namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Course")]
    public class Course
    {
        public Course()
        {
            this.CourseAwardLinks = new HashSet<CourseAwardLink>();
            this.CourseItemLinks = new HashSet<CourseItemLink>();
            this.Sections = new HashSet<Section>();
        }

        // Primary Key
        [Key]
        public int Id { get; set; }

        // The course number
        [Display(Name = "Course Number"), Required]
        public string Number { get; set; }

        // The course name
        [Display(Name = "Course Name"), Required]
        public string Name { get; set; }

        // Makes a course active
        [Display(Name = "Active")]
        public bool Active { get; set; }
    
        // extends to IOCollection CourseAwardsLinks
        public virtual ICollection<CourseAwardLink> CourseAwardLinks { get; set; }

        // extends to IOCollection CourseItemLinks
        public virtual ICollection<CourseItemLink> CourseItemLinks { get; set; }

        // extends to IOCollection Sections
        public virtual ICollection<Section> Sections { get; set; }
    }
}
