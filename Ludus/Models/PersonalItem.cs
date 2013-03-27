namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Globalization;
    using System.Web.Security;
    [Table("PersonalItem")]
    public class PersonalItem
    {
        [Key]
        public int Id { get; set; }
        
        public int UserId { get; set; }

        [Display(Name = "Due")]
        [Required]
        public System.DateTime Due { get; set; }

        [Display(Name = "Short Description")]
        [Required]
        public string ShortDescription { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Complete")]
        [Required]
        public bool Complete { get; set; }
    }
}
