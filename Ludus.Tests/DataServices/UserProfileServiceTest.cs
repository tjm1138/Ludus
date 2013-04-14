/*
 * Unit tests for the User Profile Service
 * Tests the Find, Update and Gravatar methods of the User Profile Service
 * Kassandra Coan
 * klc11k
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ludus.Tests.DataServices
{
    using Ludus.DataServices;
    using Ludus.Filters;
    [TestClass]
    [InitializeSimpleMembership]
    public class UserProfileServiceTest
    {
        /// <summary>
        /// The Find method returns a single user profile.
        /// </summary>
        [TestMethod]
        public void FindTest() 
        {
            // Arrange
            UserProfileService service = new UserProfileService();
            // Act
            var item = service.Find(1);
            // Assert
            Assert.IsNotNull(item);
            // Assert
            Assert.AreEqual(item.Id, 1);
        }

        /* INCOMPLETE
        /// <summary>
        /// Ensure that biography updates
        /// </summary>
        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            UserProfileService service = new UserProfileService();
            // Act
            var item = service.Find(1);
            // Assert
            Assert.IsNotNull(item);
            // Act
            var biography = item.Biography;
            var newBiography = "BIOGRAPHY TEST";
            service.Update(item);
            var item2 = service.Find(1);
            // Assert
            Assert.IsNotNull(item2);
            // Assert
            Assert.AreEqual (item2.Notes, newNotes);
        }
         */
         
        /// <summary>
        /// Gravatar: check with a predeterined email, that the hash is calculated correctly.
        /// </summary>
        [TestMethod]
        public void GrvatarTest()
        {
            // Arrange
            UserProfileService service = new UserProfileService();
            // Act
            var returnedOutput = service.Gravatar('kassycoan@gmail.com');
            Assert.AreEqual("http://www.gravatar.com/avatar/32cfc1315fecbc04d689b8bcb03d3caf?d=http://ludus.azurewebsites.net/Images/defaultProfile.jpg", returnedOutput);
        }
    }
}
