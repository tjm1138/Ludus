namespace Ludus.DataServices
{
    using Ludus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Security;
    public class SectionService : IDisposable
    {
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();
        public Section Find(int Id)
        {
            Section returnValue = (from s in dc.Sections
                                   where s.Id == Id
                                   select s).FirstOrDefault();
            using (CourseService svc = new CourseService())
            {
                returnValue.Course = svc.Find(returnValue.CourseId);
            }
            return returnValue;
        }

        public void Dispose()
        {
            dc.Dispose();
        }
    }
}