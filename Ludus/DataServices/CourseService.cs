/*
CourseService - Provides integrated course data to be used by the controller.
Shawn Williams
March 31, 2013
*/
namespace Ludus.DataServices
{
    using Ludus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;
    public class CourseService : IDisposable
    {
        // Get methods return collections of objects, find methods return single objects.
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();
        // Method for displaying a list of courses
        public ICollection<Course> DisplayCourses()
        {
            ICollection<Course> returnValue;
            returnValue = (from c in dc.Courses
                           select c).ToList();
            return returnValue;
        }
        // Method to find courses
        public Course Find(int id)
        {
            return dc.Courses.Find(id);
            
        }
        // Method for deleting courses
        public void Remove(int id)
        {
            Course Course = Find(id);
            dc.Courses.Remove(Course);
            dc.SaveChanges();
        }
        // Method for creating courses
        public int Create(Course course)
        {
            dc.Courses.Add(course);
            dc.SaveChanges();
            return course.Id;
        }
        // Method for updating courses
        public void Update(Course item)
        {
            dc.Entry(item).State = EntityState.Modified;
            dc.SaveChanges();
        }
        // Calls dispose
        public void Dispose()
        {
            dc.Dispose();
        }
    }
}