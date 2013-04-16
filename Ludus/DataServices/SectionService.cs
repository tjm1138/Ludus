/*
SectionService - Provides integrated section data to be used by the controller.
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
    public class SectionService : IDisposable
    {
        // Get methods return collections of objects, find methods return single objects.
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();

        // Method for displaying a list of sections
        public ICollection<Section> DisplaySections()
        {
            ICollection<Section> returnValue;
            returnValue = (from sess in dc.Sections
                           select sess).ToList();
            return returnValue;
        }
        
        // Method to find sections
        public Section Find(int id)
        {
            return dc.Sections.Find(id);
        }

        // Method for removing sections
        public void Remove(int id)
        {
            Section section = Find(id);
            dc.Sections.Remove(section);
            dc.SaveChanges();
        }

        // Method for creating sections
        public void Create(Section section)
        {
            dc.Sections.Add(section);
            dc.SaveChanges();
        }

        // Method for updating sections
        public void Update(Section section)
        {
            dc.Entry(section).State = EntityState.Modified;
            dc.SaveChanges();
        }

        // Calls dispose
        public void Dispose()
        {
            dc.Dispose();
        }
    }
}