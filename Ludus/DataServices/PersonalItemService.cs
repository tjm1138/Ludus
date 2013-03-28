namespace Ludus.DataServices
{
    using Ludus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Security;
    public class PersonalItemService : IDisposable
    {
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();
        public ICollection<PersonalItem> Get(int userId)
        {
            ICollection<PersonalItem> returnValue;
            returnValue = (from pi in dc.PersonalItems
                       where (pi.UserId == userId)
                       select pi).ToList();
            return returnValue;
        }
        public PersonalItem Find(int id)
        {
            return dc.PersonalItems.Find(id);
        }
        public void Remove(int id)
        {
            PersonalItem item = Find(id);
            dc.PersonalItems.Remove(item);
            dc.SaveChanges();
        }
        public void Create(PersonalItem item)
        {
            dc.PersonalItems.Add(item);
            dc.SaveChanges();
        }
        public void Update(PersonalItem item)
        {
            dc.Entry(item).State = EntityState.Modified;
            dc.SaveChanges();
        }

        public void Dispose()
        {
            dc.Dispose();
        }
    }
}