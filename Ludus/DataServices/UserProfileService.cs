
namespace Ludus.DataServices
{
    using Ludus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Security.Cryptography;
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
            UserProfile returnValue;
            returnValue = (from profile in dc.UserProfiles
                           where (profile.UserId == userId)
                           select profile).FirstOrDefault();
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

        public void Dispose()
        {
            dc.Dispose();
        }
    }
}
