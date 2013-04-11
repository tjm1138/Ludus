namespace Ludus.DataServices
{
    using Ludus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;
    public class FacultyService : IDisposable
    {
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();
        
        public ICollection<Faculty> DisplayFaculties()
        {
            ICollection<Faculty> returnValue;
            returnValue = (from s in dc.Faculties
                           select s).ToList();
            return returnValue;
        }
        
        public Faculty Find(int id)
        {
            return dc.Faculties.Find(id);
        }
        
        public void Remove(int id)
        {
            Faculty Faculty = Find(id);
            dc.Faculties.Remove(Faculty);
            dc.SaveChanges();
        }
        
        public void Create(Faculty faculty)
        {
            dc.Faculties.Add(faculty);
            dc.SaveChanges();
        }
        
        public void Update(Faculty faculty)
        {

            dc.Entry(faculty).State = EntityState.Modified;
            dc.SaveChanges();
        }

        public void Dispose()
        {
            dc.Dispose();
        }
    }
}