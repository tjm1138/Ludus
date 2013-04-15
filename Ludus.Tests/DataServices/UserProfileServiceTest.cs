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
            Assert.AreEqual(item.UserId, 1);
        }
         
        /// <summary>
        /// Gravatar: check with a predeterined email, that the hash is calculated correctly.
        /// </summary>
        [TestMethod]
        public void GrvatarTest()
        {
            // Arrange
            UserProfileService service = new UserProfileService();
            // Act
            var returnedOutput = service.Gravatar("kassycoan@gmail.com");
            Assert.AreEqual("http://www.gravatar.com/avatar/32cfc1315fecbc04d689b8bcb03d3caf?d=http://ludus.azurewebsites.net/Images/defaultProfile.jpg", returnedOutput);
        }

        /// <summary>
        /// Ensure that a call to update actaully writes
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
            item.Biography = String.Format("UPDATE BIOGRAPHY TEST");
            var newBiography = item.Biography;
            service.Update(item);
            var item2 = service.Find(1);
            // Assert
            Assert.IsNotNull(item2);
            // Assert
            Assert.AreEqual(item2.Biography, newBiography);
            item2.Biography = biography;
            service.Update(item2);
            var item3 = service.Find(1);
            // Assert
            Assert.IsNotNull(item2);
            // Assert
            Assert.AreEqual(item3.Biography, biography);
        }

    }
}
