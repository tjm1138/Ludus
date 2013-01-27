using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Models
{
    public class CalendarContext : DbContext
    {
        public CalendarContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<ScheduleItemProfile> ScheduleItemProfiles { get; set; }
    }

    public class ScheduleItemProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ScheduleItemId { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public bool AllDay { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
    public class CalendarModel
    {
    }
}
