using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using Ludus.Filters;
namespace Ludus.Models
{
    [InitializeSimpleMembership]
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<PersonalItem> PersonalItems { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseAwardLink> CourseAwardLinks { get; set; }
        public DbSet<CourseItemLink> CourseItemLinks { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<RolePermissionLink> RolePermissionLinks { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentBadgeLink> StudentBadgeLinks { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}