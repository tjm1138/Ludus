namespace Ludus.DataServices
{
    using Ludus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;
    public class SessionService : IDisposable
    {
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();
        public ICollection<Session> DisplaySessions()
        {
            ICollection<Session> returnValue;
            returnValue = (from pi in dc.Sessions
                           select pi).ToList();
            return returnValue;
        }
        public Session Find(int id)
        {
            return dc.Sessions.Find(id);
        }
        public void Remove(int id)
        {
            Session session = Find(id);
            dc.Sessions.Remove(session);
            dc.SaveChanges();
        }
        public void Create(Session session)
        {
            dc.Sessions.Add(session);
            dc.SaveChanges();
        }
        public void Update(Session item)
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