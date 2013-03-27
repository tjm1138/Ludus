using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Globalization;
using System.Web.Security;

namespace Models
{
    public class PersonalItemContext : DbContext
    {
        public PersonalItemContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Ludus.LinqModels.PersonalItem> Items { get; set; }
    }
}
