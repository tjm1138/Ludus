namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Item")]
    public class Item
    {
        public Item()
        {
            this.CourseItemLinks = new HashSet<CourseItemLink>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<CourseItemLink> CourseItemLinks { get; set; }
    }
}
