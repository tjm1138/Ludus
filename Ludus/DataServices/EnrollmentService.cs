﻿namespace Ludus.DataServices
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
                              join stu in dc.Students on enr.StudentId equals stu.Id
                              join sec in dc.Sections on enr.SectionId equals sec.Id
                              join ses in dc.Sessions on sec.SessionId equals ses.Id
                              where stu.UserId == UserId && ses.Active == true
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
            Enrollment returnValue = (from e in dc.Enrollments
                                  where e.Id == Id
                                  select e).FirstOrDefault();
            return returnValue;
        }


        public void Dispose()
        {
            dc.Dispose();
        }
    }
}