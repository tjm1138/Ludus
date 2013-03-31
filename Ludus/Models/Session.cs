namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Session")]
    public class Session
    {
        public Session()
        {
            this.Faculties = new HashSet<Faculty>();
            this.Sections = new HashSet<Section>();
            this.Students = new HashSet<Student>();
        }
        [Key]
        public int Id { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Faculty> Faculties { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
