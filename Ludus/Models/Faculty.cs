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
        public int UserId { get; set; }
        public int SessionId { get; set; }

        [ForeignKey("SessionId")]
        public virtual Session Session { get; set; }
        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile { get; set; }
    }
}
