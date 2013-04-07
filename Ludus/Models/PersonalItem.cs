/*
 * PersonalItem - Object for the items of an individual
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
    [Table("PersonalItem")]
    public class PersonalItem : CalendarBase
    {
        // The User ID of the individual
        [Display(Name = "User Id"), Required]
        public int UserId { get; set; }

        // A flag if the item can be marked complete
        [Display(Name = "Complete"), Required]
        public bool Complete { get; set; }
    }
}
