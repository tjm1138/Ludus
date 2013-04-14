using System;
namespace Ludus.Models
{
    interface IDataContext
    {
        System.Data.Entity.DbSet<Assignment> Assignments { get; set; }
        System.Data.Entity.DbSet<Award> Awards { get; set; }
        System.Data.Entity.DbSet<Badge> Badges { get; set; }
        System.Data.Entity.DbSet<CourseAwardLink> CourseAwardLinks { get; set; }
        System.Data.Entity.DbSet<CourseItemLink> CourseItemLinks { get; set; }
        System.Data.Entity.DbSet<Course> Courses { get; set; }
        System.Data.Entity.DbSet<Enrollment> Enrollments { get; set; }
        System.Data.Entity.DbSet<Faculty> Faculties { get; set; }
        System.Data.Entity.DbSet<Item> Items { get; set; }
        System.Data.Entity.DbSet<Permission> Permissions { get; set; }
        System.Data.Entity.DbSet<PersonalItem> PersonalItems { get; set; }
        System.Data.Entity.DbSet<Quiz> Quizs { get; set; }
        System.Data.Entity.DbSet<RolePermissionLink> RolePermissionLinks { get; set; }
        System.Data.Entity.DbSet<Section> Sections { get; set; }
        System.Data.Entity.DbSet<Session> Sessions { get; set; }
        System.Data.Entity.DbSet<StudentBadgeLink> StudentBadgeLinks { get; set; }
        System.Data.Entity.DbSet<Student> Students { get; set; }
        System.Data.Entity.DbSet<Submission> Submissions { get; set; }
        System.Data.Entity.DbSet<UserProfile> UserProfiles { get; set; }
    }
}
