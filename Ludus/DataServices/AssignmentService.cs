/*
 * AssignmentServices - Used for Controllers to access data models
 * Thomas Moseley
 * Shawn Williams
 * April 14, 2013
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


        public ICollection<Assignment> DisplayAssignments()
        {
            ICollection<Assignment> returnValue;
            returnValue = (from s in dc.Assignments
                           select s).ToList();
            return returnValue;
        }

        public Assignment Find(int id)
        {
            return dc.Assignments.Find(id);
        }
        public void Remove(int id)
        {
            Assignment assignment = Find(id);
            dc.Assignments.Remove(assignment);
            dc.SaveChanges();
        }

        public void Create(Assignment assignment)
        {
            dc.Assignments.Add(assignment);
            dc.SaveChanges();
        }

        public void Update(Assignment assignment)
        {

            dc.Entry(assignment).State = EntityState.Modified;
            dc.SaveChanges();
        }

        public void Dispose()
        {
   //         dc.Dispose();
        }
    }
}