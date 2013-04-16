/*
SessionService - Provides integrated session data to be used by the controller.
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
    public class SessionService : IDisposable
    {
        // Get methods return collections of objects, find methods return single objects.
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();

        // Method for displaying a list of sessions
        public ICollection<Session> DisplaySessions()
        {
            ICollection<Session> returnValue;
            returnValue = (from pi in dc.Sessions
                           select pi).ToList();
            return returnValue;
        }
        
        // Method to find sessions
        public Session Find(int id)
        {
            return dc.Sessions.Find(id);
        }
        
        // Method for removing sessions
        public void Remove(int id)
        {
            Session session = Find(id);
            dc.Sessions.Remove(session);
            dc.SaveChanges();
        }

        // Method for creating sessions
        public void Create(Session session)
        {
            dc.Sessions.Add(session);
            dc.SaveChanges();
        }

        // Method for updating sessions
        public void Update(Session item)
        {
            dc.Entry(item).State = EntityState.Modified;
            dc.SaveChanges();
        }

        // Calls dispose
        public void Dispose()
        {
            dc.Dispose();
        }
    }
}