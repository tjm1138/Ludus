//select * from Assignment 
//	join section on section.id = Assignment.SectionId
//	join course on course.Id = section.CourseId
//where Assignment.SectionId in (select SectionId
//	from Enrollment
//	join Student on Student.id = Enrollment.StudentId
//	where Student.UserId = 5
//	and Student.SessionId = 1
//)
namespace Ludus.DataServices
{
    using Ludus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;
    public class AssignmentService : IDisposable
    {       
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();
        public ICollection<Assignment> Get(int userId)
        {
            var sectionIds = (from e in new EnrollmentService().Get(userId)
                             select e.SectionId).ToList();
            ICollection<Assignment> returnValue;
            if (sectionIds.Count() > 0)
            {
                returnValue = (from a in dc.Assignments
                               where sectionIds.Contains(a.SectionId)
                               select a).ToList();
            }
            else
            {
                returnValue = new List<Assignment>();
            }
            return returnValue;
        }
        public Assignment Find(int id)
        {
            return dc.Assignments.Find(id);
        }
        public void Dispose()
        {
            dc.Dispose();
        }
    }
}