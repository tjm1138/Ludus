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
        public Calendar Get(int userId)
        {
            Calendar returnValue = new Calendar();
            using (var svc = new PersonalItemService())
            {
                returnValue.PersonalItems = svc.Get(userId);
            }
            using (var svc = new AssignmentService())
            {
                returnValue.Assignments = svc.Get(userId);
            }
            return returnValue;
        }

        public void Dispose()
        {
        }
    }
}
