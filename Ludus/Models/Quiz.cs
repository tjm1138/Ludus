namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;    
    [Table("Quiz")]
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> TimeBegin { get; set; }
        public Nullable<System.DateTime> TimeEnd { get; set; }
        public int Points { get; set; }
    
        public virtual Section Section { get; set; }
    }
}
