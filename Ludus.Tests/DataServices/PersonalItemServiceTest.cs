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
            AssignmentService service = new AssignmentService();

            // Act
            var item = service.Find(1);

            // Assert
            Assert.IsNotNull(item);

            // Assert
            Assert.Equals(item.Id, 1);
        }
    }
}
