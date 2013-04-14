/*
Session Model - All session-related items derive from this.
Shawn Williams
March 31, 2013
*/

namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    // SQL table Session
    [Table("Session")]
    public class Session
    {
        public Session()
        {
            this.Faculties = new HashSet<Faculty>();
            this.Sections = new HashSet<Section>();
            this.Students = new HashSet<Student>();
        }
        
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Start Date
        [Display(Name = "Start Date")]
        [Required]
        public System.DateTime StartDate { get; set; }

        // End Date
        [Display(Name = "End Date")]
        [Required]
        public System.DateTime EndDate { get; set; }

        // Make the Session Active
        [Display(Name = "Active Session")]
        public bool Active { get; set; }

        // Session Name
        [Display(Name = "Session Name")]
        [Required]
        public string Name { get; set; }
    
        // extends IOCollection Faculty
        public virtual ICollection<Faculty> Faculties { get; set; }

        // extends IOCollection Sections
        public virtual ICollection<Section> Sections { get; set; }

        // extends IOCollection Students
        public virtual ICollection<Student> Students { get; set; }
    }
}
