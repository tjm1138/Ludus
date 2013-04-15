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
        /// Ensure that a biography actaully updates
        /// </summary>
        [TestMethod]
        public void UpdateBiography()
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

        /// <summary>
        /// Searching for an invalid id. Should always return null
        /// </summary>
        [TestMethod]
        public void FindWithErrorID()
        {
            // Arrange
            UserProfileService service = new UserProfileService();
            // Act
            var item = service.Find(-1);
            // Assert
            Assert.IsNull(item);
        }

        /// <summary>
        /// Ensure that a First Name actaully updates
        /// </summary>
        [TestMethod]
        public void UpdateFirstName()
        {
            // Arrange
            UserProfileService service = new UserProfileService();
            // Act
            var item = service.Find(1);
            // Assert
            Assert.IsNotNull(item);
            // Act
            var firstName = item.FirstName;
            item.FirstName = String.Format("UPDATE FIRST NAME TEST");
            var newFirstName = item.FirstName;
            service.Update(item);
            var item2 = service.Find(1);
            // Assert
            Assert.IsNotNull(item2);
            // Assert
            Assert.AreEqual(item2.FirstName, newFirstName);
            item2.FirstName = firstName;
            service.Update(item2);
            var item3 = service.Find(1);
            // Assert
            Assert.IsNotNull(item2);
            // Assert
            Assert.AreEqual(item3.FirstName, firstName);
        }

        /// <summary>
        /// Ensure that a Last Name actaully updates
        /// </summary>
        [TestMethod]
        public void UpdateLastName()
        {
            // Arrange
            UserProfileService service = new UserProfileService();
            // Act
            var item = service.Find(1);
            // Assert
            Assert.IsNotNull(item);
            // Act
            var lastName = item.LastName;
            item.LastName = String.Format("UPDATE LAST NAME TEST");
            var newLastName = item.LastName;
            service.Update(item);
            var item2 = service.Find(1);
            // Assert
            Assert.IsNotNull(item2);
            // Assert
            Assert.AreEqual(item2.LastName, newLastName);
            item2.LastName = lastName;
            service.Update(item2);
            var item3 = service.Find(1);
            // Assert
            Assert.IsNotNull(item2);
            // Assert
            Assert.AreEqual(item3.LastName, lastName);
        }

        /// <summary>
        /// Ensure that a Display Name actaully updates
        /// </summary>
        [TestMethod]
        public void UpdateDisplayName()
        {
            // Arrange
            UserProfileService service = new UserProfileService();
            // Act
            var item = service.Find(1);
            // Assert
            Assert.IsNotNull(item);
            // Act
            var displayName = item.DisplayName;
            item.DisplayName = String.Format("UPDATE DISPLAY NAME TEST");
            var newDisplayName = item.DisplayName;
            service.Update(item);
            var item2 = service.Find(1);
            // Assert
            Assert.IsNotNull(item2);
            // Assert
            Assert.AreEqual(item2.DisplayName, newDisplayName);
            item2.DisplayName = displayName;
            service.Update(item2);
            var item3 = service.Find(1);
            // Assert
            Assert.IsNotNull(item2);
            // Assert
            Assert.AreEqual(item3.DisplayName, displayName);
        }

        /// <summary>
        /// Ensure that a Email Address actaully updates
        /// </summary>
        [TestMethod]
        public void UpdateEmailAddressName()
        {
            // Arrange
            UserProfileService service = new UserProfileService();
            // Act
            var item = service.Find(1);
            // Assert
            Assert.IsNotNull(item);
            // Act
            var emailAddress = item.EmailAddress;
            item.EmailAddress = String.Format("UPDATE EmailAddress TEST");
            var newEmailAddress = item.EmailAddress;
            service.Update(item);
            var item2 = service.Find(1);
            // Assert
            Assert.IsNotNull(item2);
            // Assert
            Assert.AreEqual(item2.EmailAddress, newEmailAddress);
            item2.EmailAddress = emailAddress;
            service.Update(item2);
            var item3 = service.Find(1);
            // Assert
            Assert.IsNotNull(item2);
            // Assert
            Assert.AreEqual(item3.EmailAddress, emailAddress);
        }

    }
}
