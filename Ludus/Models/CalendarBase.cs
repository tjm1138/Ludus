
namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Globalization;
    using System.Web.Security;
    public class CalendarBase
    {
        public int Id { get; set; }

        [Display(Name = "Due")]
        [Required]
        public System.DateTime Due { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

    }
}


