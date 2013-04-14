/*
 * Calendar - A model for the execution of Home Page.
 * Thomas Moseley
 * April 14, 2013
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
    public class Calendar
    {
        public DateTime DisplayMonth;
        public ICollection<CalendarBase> Items { get; set; }
        public Calendar()
        {
            Items = new List<CalendarBase>();
        }
    }
}
