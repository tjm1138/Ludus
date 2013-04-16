/*
FacultyService - Provides integrated faculty data to be used by the controller.
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
    public class FacultyService : IDisposable
    {
        // Get methods return collections of objects, find methods return single objects.
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();

        // Method for displaying a list of faculty members
        public ICollection<Faculty> DisplayFaculties()
        {
            ICollection<Faculty> returnValue;
            returnValue = (from s in dc.Faculties
                           select s).ToList();
            return returnValue;
        }
        
        // Method to find faculty members
        public Faculty Find(int id)
        {
            return dc.Faculties.Find(id);
        }
        
        // Method for removing faculty members
        public void Remove(int id)
        {
            Faculty Faculty = Find(id);
            dc.Faculties.Remove(Faculty);
            dc.SaveChanges();
        }

        // Method for creating faculty members
        public void Create(Faculty faculty)
        {
            dc.Faculties.Add(faculty);
            dc.SaveChanges();
        }

        // Method for updating faculty members
        public void Update(Faculty faculty)
        {
            dc.Entry(faculty).State = EntityState.Modified;
            dc.SaveChanges();
        }

        // Calls dispose
        public void Dispose()
        {
            dc.Dispose();
        }
    }
}