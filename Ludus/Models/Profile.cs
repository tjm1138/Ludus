/*
 * Profile - A User Profile
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
    public class Profile
    {
        public UserProfile User { get; set; }
        public string Gravatar { get; set; }
        public ICollection<Badge> Badges { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}


