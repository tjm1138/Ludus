namespace Ludus.DataServices
{
    using Ludus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Security;
    public class BadgesService : IDisposable
    {
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();
        public ICollection<Badge> Get(int userId)
        {
            ICollection<Badge> returnValue;
            returnValue = (from b in dc.Badges
                       //where (pi.Id == userId)
                       select b).ToList();
            return returnValue;
        }
        public Badge Find(int id)
        {
            return dc.Badges.Find(id);
        }
        public void Remove(int id)
        {
            Badge item = Find(id);
            dc.Badges.Remove(item);
            dc.SaveChanges();
        }
        public void Create(Badge badge)
        {
            dc.Badges.Add(badge);
            dc.SaveChanges();
        }
        public void Update(Badge badge)
        {
            dc.Entry(badge).State = EntityState.Modified;
            dc.SaveChanges();
        }

        public void Dispose()
        {
            dc.Dispose();
        }
    }
}