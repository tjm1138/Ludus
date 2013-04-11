namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Faculty")]
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "User Id"), Required]
        public int UserId { get; set; }

        [Display(Name = "Session Id"), Required]
        public int SessionId { get; set; }
        public virtual Session Session { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
