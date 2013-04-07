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
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();
        public ICollection<Student> DisplayStudents()
        {
            ICollection<Student> returnValue;
            returnValue = (from s in dc.Students
                           select s).ToList();
            return returnValue;
        }
        public Student Find(int id)
        {
            return dc.Students.Find(id);
        }
        public void Remove(int id)
        {
            Student student = Find(id);
            dc.Students.Remove(student);
            dc.SaveChanges();
        }
        public void Create(Student student)
        {
            //student.UserId = 
            //student.SessionId = 
            dc.Students.Add(student);
            dc.SaveChanges();
        }
        public void Update(Student student)
        {
            
            dc.Entry(student).State = EntityState.Modified;
            dc.SaveChanges();
        }
        public ICollection<Session> DisplaySessions()
        {
            ICollection<Session> returnValue;
            returnValue = (from sess in dc.Sessions
                           select sess).ToList();
            return returnValue;
        }


        public void Dispose()
        {
            dc.Dispose();
        }
    }
}