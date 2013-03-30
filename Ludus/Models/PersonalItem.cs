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
    public class PersonalItem : CalendarBase
    {
        [Display(Name = "User Id")]
        [Required]
        public int UserId { get; set; }

        [Display(Name = "Complete")]
        [Required]
        public bool Complete { get; set; }
    }
}
