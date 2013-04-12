namespace Ludus.DataServices
{
    using Ludus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;
    public class EnrollmentService : IDisposable
    {
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();
        public ICollection<Enrollment> Get(int UserId)
        {
            var enrollments = (from enr in dc.Enrollments
                               where enr.Student.UserId == UserId 
                               && enr.Section.Session.Active == true
                              select enr).ToList();
            using (SectionService svc = new SectionService())
            {
                foreach (Enrollment e in enrollments)
                {
                    e.Section = svc.Find(e.SectionId);
                }
            }
            return enrollments;
        }
        public Enrollment Find(int Id)
        {
            return dc.Enrollments.Find(Id);
        }


        public void Dispose()
        {
            dc.Dispose();
        }
    }
}