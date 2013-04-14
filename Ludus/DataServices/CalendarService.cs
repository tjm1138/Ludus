/*
 * Calendar Service - Provides integrated calendar data (not assignments or personal items individually.
 * Thomas Moseley
 * May 31, 2013
*/
namespace Ludus.DataServices
{
    using Ludus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Security;
    
    public class CalendarService : IDisposable
    {
        private DataServices.PersonalItemService pi = new DataServices.PersonalItemService();
        private DataServices.AssignmentService a = new DataServices.AssignmentService();
        // By convention - Get methods return collections of objects, find methods return single objects. 
        public Calendar Find(int userId)
        {
            // The Calendar object is a collection of CalendarBase objects
            Calendar returnValue = new Calendar();
            // First, we fill the Personal Items
                returnValue.Items = (from i in pi.Get(userId) select (CalendarBase) i).ToList();
            // First, we fill the Assignments
           foreach (CalendarBase b in (from i in a.Get(userId) select (CalendarBase)i))
                returnValue.Items.Add(b);
            return returnValue;
        }
        // By convention - Get methods return collections of objects, find methods return single objects. 
        public Calendar Find(int userId, DateTime month)
        {
            // The Calendar object is a collection of CalendarBase objects
            Calendar returnValue = Find(userId);
            returnValue.DisplayMonth = month;
            return returnValue;
        }

        public void Dispose()
        {
            pi.Dispose();
            a.Dispose();
        }
    }
}
