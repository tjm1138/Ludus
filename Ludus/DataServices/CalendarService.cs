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
                returnValue.Items = (from i in svc.Get(userId) select (CalendarBase) i).ToList();
            }
            using (var svc = new AssignmentService())
            {
                foreach (CalendarBase b in (from i in svc.Get(userId) select (CalendarBase)i))
                    returnValue.Items.Add(b);
            }
            returnValue.Items.OrderBy(c => c.Due);
            return returnValue;
        }

        public void Dispose()
        {
        }
    }
}
