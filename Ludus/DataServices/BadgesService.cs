namespace Ludus.DataServices
{
    using Ludus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Security;

    /******************
    Author:  Adam Gorman
    Company:  Ludus 
    Name of File: BadgesService.cs
    Date Created: 2013-3-30
    Description:  This file handle the Badges services, primarily for accessing the database, such as returning the list that meet certain criteria, as well as
     * adding, updating, and such for the Badges
    *******************/

    public class BadgesService : IDisposable
    {
        private Ludus.Models.DataContext dc = new Ludus.Models.DataContext();
        
        //This will get the current set of badges available and return them to be displayed
        public ICollection<Badge> Get(int id)
        {
            ICollection<Badge> returnValue;
            returnValue = (from b in dc.Badges
                       select b).ToList();
            return returnValue;
        }
        //To find a specific badge by id, this method would be used
        public Badge Find(int id)
        {
            return dc.Badges.Find(id);
        }

        //If a badge needs to be removed, this will remove the specified badge
        public void Remove(int id)
        {
            Badge item = Find(id);
            dc.Badges.Remove(item);
            dc.SaveChanges();
        }

        //If a badge needs to be created, this will create the specified badge with certain required properties
        public void Create(Badge badge)
        {
            dc.Badges.Add(badge);
            dc.SaveChanges();
        }

        //If a change is being made to an existing badge, this will modify it.
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