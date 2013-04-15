/*
 * Unit tests for the Course Service
 * Tests the Find, Get, Create, Update and Delete methods of the Course Service
 * Shawn Williams
 * spw09
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ludus.Tests.DataServices
{
    using Ludus.DataServices;
    using Ludus.Filters;
    [TestClass]
    [InitializeSimpleMembership]
    public class CourseServiceTest
    {
        /// <summary>
        /// The Find method returns a single course.
        /// </summary>
        [TestMethod]
        public void Find_Course()
        {
            // Arrange
            CourseService service = new CourseService();
            // Act
            var course = service.Find(1);
            // Assert
            Assert.IsNotNull(course);
            // Assert
            Assert.AreEqual(course.Id, 1);
        }
        /// <summary>
        /// The Find method returns a single course. With a -1 ID, the method should always return a null.
        /// </summary>
        [TestMethod]
        public void FindEmpty_Course()
        {
            // Arrange
            CourseService service = new CourseService();
            // Act
            var course = service.Find(-1);
            // Assert
            Assert.IsNull(course);
        }
        /// <summary>
        /// The DisplayCourses method returns a list of courses.
        /// </summary>
        [TestMethod]
        public void DisplayCourses_Course()
        {
            // Arrange
            CourseService service = new CourseService();
            // Act
            var courses = service.DisplayCourses();
            // Assert
            Assert.IsNotNull(courses);
            // Assert
            Assert.AreNotEqual(courses.Count, 0);
        }
        /// <summary>
        /// Since the Find() test ensures that we will get an course with an ID of 1, let's make a change and ensure it takes.
        /// </summary>
        [TestMethod]
        public void Update_Course()
        {
            // Arrange
            CourseService service = new CourseService();
            // Act
            var course = service.Find(1);
            // Assert
            Assert.IsNotNull(course);
            // Act
            var names = course.Name;
            course.Name = String.Format("Course TEST {0:d}", DateTime.Now);
            var newNotes = course.Name;
            service.Update(course);
            var course2 = service.Find(1);
            // Assert
            Assert.IsNotNull(course2);
            // Assert
            Assert.AreEqual(course2.Name, newNotes);
            course2.Name = names;
            service.Update(course2);
            var course3 = service.Find(1);
            // Assert
            Assert.IsNotNull(course2);
            // Assert
            Assert.AreEqual(course3.Name, names);
        }
        /// <summary>
        /// We group the Create and Delete tests, to delete the course which we create.
        /// </summary>
        [TestMethod]
        public void CreateDelete_Course()
        {
            // Arrange
            CourseService service = new CourseService();
            // Act
            var course = new Models.Course();
            course.Id = 5;
            course.Number = "TEST1234";
            course.Name = "Test Class!!!";
            course.Active = true;
            int id = service.Create(course);
            var newcourse = service.Find(id);
            // Assert
            Assert.IsNotNull(newcourse);
            // Assert
            Assert.AreEqual(course, newcourse);
            service.Remove(id);
            var newcourse2 = service.Find(id);
            // Assert
            Assert.IsNull(newcourse2);
        }
    }
}
