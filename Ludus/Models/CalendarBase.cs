﻿
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

        [Display(Name = "Due"), Required, DataType(DataType.DateTime)]
        public System.DateTime Due { get; set; }

        [Display(Name = "Description"), Required, StringLength(255), DataType (DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Notes"), StringLength(10000), DataType (DataType.MultilineText)]
        public string Notes { get; set; }

    }
}


