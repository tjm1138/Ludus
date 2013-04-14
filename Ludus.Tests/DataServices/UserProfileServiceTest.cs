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
        [TestMethod]
        public void GravatarTest()
        {
            // Arrange
            UserProfileService service = new UserProfileService();

        }
    }
}
