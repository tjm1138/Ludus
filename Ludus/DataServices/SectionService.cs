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
        public Section Find(int id)
        {
            Section returnValue = (from s in dc.Sections
                                  where s.Id == id
                                  select s).FirstOrDefault();
            return returnValue;
        }

        public void Remove(int id)
        {
            Section section = Find(id);
            dc.Sections.Remove(section);
            dc.SaveChanges();
        }
        
        public void Create(Section section)
        {
            dc.Sections.Add(section);
            dc.SaveChanges();
        }
        
        public void Update(Section section)
        {
            dc.Entry(section).State = EntityState.Modified;
            dc.SaveChanges();
        }

        public ICollection<Section> DisplaySections()
        {
            ICollection<Section> returnValue;
            returnValue = (from sess in dc.Sections
                           select sess).ToList();
            return returnValue;
        }

        public void Dispose()
        {
            dc.Dispose();
        }
    }
}