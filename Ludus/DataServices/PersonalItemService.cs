/*
 * Personal Item Services - Used for Controllers to access Personal Items
 * Thomas Moseley
 * April 14, 2013
*/
namespace Ludus.DataServices
{
    using Ludus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Security;
    /// <summary>
    /// The PersonalItemService implements IDisposable so that when it exits scope and is collected, Dispose() is called, \\
    /// releasing the data context.
    /// </summary>
    public class PersonalItemService : IDisposable
    {
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();
        /// <summary>
        /// Returns an ICollection of Personal Items for a UserId
        /// </summary>
        /// <param name="userId">The ID of the user being queried</param>
        /// <returns>an ICollection of Personal Items</returns>
        public ICollection<PersonalItem> Get(int userId)
        {
            ICollection<PersonalItem> returnValue;
            returnValue = (from pi in dc.PersonalItems
                       where (pi.UserId == userId)
                       select pi).ToList();
            return returnValue;
        }
        /// <summary>
        /// Looks up a single Personal Item
        /// </summary>
        /// <param name="id">The Primary Key Value</param>
        /// <returns>The Item looked up.</returns>
        public PersonalItem Find(int id)
        {
            return dc.PersonalItems.Find(id);
        }
        // Remove an item from teh database
        public void Remove(int id)
        {
            PersonalItem item = Find(id);
            dc.PersonalItems.Remove(item);
            dc.SaveChanges();
        }
        // Add an item and save changes
        public int Create(PersonalItem item)
        {
            dc.PersonalItems.Add(item);
            dc.SaveChanges();
            return item.Id;
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