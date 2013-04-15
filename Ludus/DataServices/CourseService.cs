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
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();
        public ICollection<Course> DisplayCourses()
        {
            ICollection<Course> returnValue;
            returnValue = (from c in dc.Courses
                           select c).ToList();
            return returnValue;
        }
        public Course Find(int id)
        {
            return dc.Courses.Find(id);
            
        }
        public void Remove(int id)
        {
            Course Course = Find(id);
            dc.Courses.Remove(Course);
            dc.SaveChanges();
        }
        public int Create(Course course)
        {
            dc.Courses.Add(course);
            dc.SaveChanges();
            return course.Id;
        }
        public void Update(Course item)
        {
            dc.Entry(item).State = EntityState.Modified;
            dc.SaveChanges();
        }
        public void Dispose()
        {
            dc.Dispose();
        }
    }
}