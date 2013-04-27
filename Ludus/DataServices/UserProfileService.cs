
namespace Ludus.DataServices
{
    using Ludus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Web.Security;
    using WebMatrix.WebData;


    public class UserProfileService : IDisposable
    {
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();

        public void Update(UserProfile item)
        {
            dc.Entry(item).State = EntityState.Modified;
            dc.SaveChanges();
        }

        // Matches the userID to a profile
        public UserProfile Find(int userId)
        {
            return dc.UserProfiles.Find(userId);
        }

        public void Dispose()
        {
            dc.Dispose();
        }
    }
}
