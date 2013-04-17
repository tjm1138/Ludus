/*
StudentService - Provides integrated student data to be used by the controller.
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
    public class StudentService : IDisposable
    {
        // Get methods return collections of objects, find methods return single objects.
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();

        // Method for displaying a list of students
        public ICollection<Student> DisplayStudents()
        {
            ICollection<Student> returnValue;
            returnValue = (from s in dc.Students
                           select s).ToList();
            return returnValue;
        }

        // Method to find students
        public Student Find(int id)
        {
            return dc.Students.Find(id);
        }
        
        // Method for removing students
        public void Remove(int id)
        {
            Student student = Find(id);
            dc.Students.Remove(student);
            dc.SaveChanges();
        }

        // Method for creating students
        public void Create(Student student)
        { 
            dc.Students.Add(student);
            dc.SaveChanges();
        }

        // Method for updating students
        public void Update(Student student)
        {
            dc.Entry(student).State = EntityState.Modified;
            dc.SaveChanges();
        }
        
        // Method for viewsing a list of sessions
        public ICollection<Session> DisplaySessions()
        {
            ICollection<Session> returnValue;
            returnValue = (from sess in dc.Sessions
                           select sess).ToList();
            return returnValue;
        }

        // Calls dispose
        public void Dispose()
        {
            dc.Dispose();
        }
    }
}