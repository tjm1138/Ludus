/*
*/
namespace Ludus.DataServices
{
    using Ludus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Security.Cryptography;
    using System.Text;
    using System.Linq;
    using System.Web.Security;
    /// <summary>
    /// The ProfileService implements IDisposable so that when it exits scope and is collected, Dispose() is called, \\
    /// releasing the data context.
    /// </summary>
    public class ProfileService : IDisposable
    {
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();

        public Profile Find(int userId)
        {
            Profile returnValue = new Profile();
            returnValue.User = dc.UserProfiles.Find(userId);
            returnValue.Badges = (from sbl in dc.StudentBadgeLinks
                                  where sbl.Student.Session.Active == true && sbl.Student.UserId == userId
                                  select sbl.Badge).ToList();
            returnValue.Enrollments = (from enr in dc.Enrollments
                                       where enr.Student.Session.Active == true && enr.Student.UserId == userId
                                       select enr).ToList();
            returnValue.Gravatar = Gravatar(returnValue.User.EmailAddress);
            return returnValue;
        }
        // Takes in the user's email address.
        // Returns the required URL to obtain their Gravatar.
        public string Gravatar(string email)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(email));

            // Create a new Stringbuilder to collect the bytes
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // formatting as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Store the hexadecimal string.
            string hexString = sBuilder.ToString();

            return "http://www.gravatar.com/avatar/" + hexString + "?d=http://ludus.azurewebsites.net/Images/defaultProfile.jpg";
        }

        void IDisposable.Dispose()
        {
            dc.Dispose();
        }
    }
}
        /// <summary>
        /// Returns an ICollection of Personal Items for a UserId
        /// </summary>
        /// <param name="userId">The ID of the user being queried</param>
        /// <returns>an ICollection of Personal Items</returns>