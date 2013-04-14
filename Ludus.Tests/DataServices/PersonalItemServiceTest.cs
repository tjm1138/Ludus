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
        [TestMethod]
        public void RetrieveItem()
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
    }
}
