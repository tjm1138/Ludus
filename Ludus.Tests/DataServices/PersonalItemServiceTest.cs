/*
 * Unit tests for the Personal Item Service
 * Tests the Find, Get, Create, Update and Delete methods of the Personal Item Service
 * Thomas Moseley
 * tjm09d
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ludus.Tests.DataServices
{
    using Ludus.DataServices;
    using Ludus.Filters;
    [TestClass]
    [InitializeSimpleMembership]
    public class PersonalItemServiceTest
    {
        /// <summary>
        /// The Find method returns a single item.
        /// </summary>
        [TestMethod]
        public void Find() 
        {
            // Arrange
            PersonalItemService service = new PersonalItemService();
            // Act
            var item = service.Find(1);
            // Assert
            Assert.IsNotNull(item);
            // Assert
            Assert.AreEqual(item.Id, 1);
        }
        /// <summary>
        /// The Find method returns a single item. With a -1 ID, the method should always return a null.
        /// </summary>
        [TestMethod]
        public void FindEmpty()
        {
            // Arrange
            PersonalItemService service = new PersonalItemService();
            // Act
            var item = service.Find(-1);
            // Assert
            Assert.IsNull(item);
        }
        /// <summary>
        /// The Get method returns a list of items. With a UserId of -1, an empty collection should be returned.
        /// </summary>
        [TestMethod]
        public void GetEmpty()
        {
            // Arrange
            PersonalItemService service = new PersonalItemService();
            // Act
            var items = service.Get(-1);
            // Assert
            Assert.IsNotNull(items);
            // Assert
            Assert.AreEqual(items.Count, 0);
        }
        /// <summary>
        /// The Get method returns a list of items. The UserId 5 should always have items
        /// </summary>
        [TestMethod]
        public void Get()
        {
            // Arrange
            PersonalItemService service = new PersonalItemService();
            // Act
            var items = service.Get(5);
            // Assert
            Assert.IsNotNull(items);
            // Assert
            Assert.AreNotEqual(items.Count, 0);
            foreach (var item in items)
            {
                Assert.AreEqual(item.UserId, 5);
            }
        }
        /// <summary>
        /// Since the Find() test ensures that we will get an item with an ID of 1, let's make a change and ensure it takes.
        /// </summary>
        [TestMethod]
        public void Update()
        {
            // Arrange
            PersonalItemService service = new PersonalItemService();
            // Act
            var item = service.Find(1);
            // Assert
            Assert.IsNotNull(item);
            // Act
            var notes = item.Notes;
            item.Notes = String.Format("NOTE TEST {0:d}", DateTime.Now);
            var newNotes = item.Notes;
            service.Update(item);
            var item2 = service.Find(1);
            // Assert
            Assert.IsNotNull(item2);
            // Assert
            Assert.AreEqual (item2.Notes, newNotes);
            item2.Notes = notes;
            service.Update(item2);
            var item3 = service.Find(1);
            // Assert
            Assert.IsNotNull(item2);
            // Assert
            Assert.AreEqual(item3.Notes, notes);
        }
        /// <summary>
        /// We group the Create and Delete tests, to delete the item which we create.
        /// </summary>
        [TestMethod]
        public void CreateDelete()
        {
            // Arrange
            PersonalItemService service = new PersonalItemService();
            // Act
            var item = new Models.PersonalItem();
            item.UserId = 5;
            item.Due = DateTime.Today;
            item.Description = "TEST TEST";
            item.Notes = "TEST TEST";
            item.Complete = false;
            int id = service.Create(item);
            var newItem = service.Find(id);
            // Assert
            Assert.IsNotNull(newItem);
            // Assert
            Assert.AreEqual(item, newItem);
            service.Remove(id);
            var newItem2 = service.Find(id);
            // Assert
            Assert.IsNull(newItem2);
        }
    }
}
