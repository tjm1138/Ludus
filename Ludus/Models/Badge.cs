namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Badge")]
    public class Badge
    {
        public Badge()
        {
            this.StudentBadgeLinks = new HashSet<StudentBadgeLink>();
        }

        
        //[Display(Name = "Id"), Required]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Section"), Required]
        public int SectionId { get; set; }
        [Display(Name = "The Name"), StringLength(1000), DataType(DataType.MultilineText), Required]
        public string Name { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }
        public virtual ICollection<StudentBadgeLink> StudentBadgeLinks { get; set; }
    }
}
