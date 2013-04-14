/*
 * CalendarBase - All calendar-related items derive from this.
 * Thomas Moseley
 * May 31, 2013
*/
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
        // The date the item is due. 
        [Display(Name = "Due Date"), Required, DataType(DataType.DateTime)]
        public System.DateTime Due { get; set; }

        // A short (<256 character) description
        [Display(Name = "Description"), Required, StringLength(255), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        // A longer amount of information
        [Display(Name = "Notes"), StringLength(10000), DataType(DataType.MultilineText)]
        public string Notes { get; set; }

    }
}


