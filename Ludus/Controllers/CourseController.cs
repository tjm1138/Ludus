/*
CourseController - Controls interactions between views in the Course folder and models.
Shawn Williams
March 31, 2013
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ludus.Filters;
using Ludus.Models;
using WebMatrix.WebData;

namespace Ludus.Controllers
{
    // This attribute, coded in Ludus.Filters, initializes the Membership system for inquiries, such as WebSecurity.CurrentUserId
    [InitializeSimpleMembership]
    public class CourseController : Controller
    {
        private DataServices.CourseService ds = new DataServices.CourseService();
        private DataContext dc = new DataContext();

        // Retrieves a list of courses from CourseService
        public ActionResult Index()
        {
            ViewBag.Label = "Courses";
            return View(ds.DisplayCourses());
        }

        // Displays the Create view
        public ActionResult Create()
        {
            return View();
        }


        // Displays the Post for Create view
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                ds.Create(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // Displays the Edit view
        public ActionResult Edit(int id = 0)
        {
            Course course = ds.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // Displays the Post for Edit view
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                ds.Update(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // Displays the Delete view
        public ActionResult Delete(int id = 0)
        {
            Course course = ds.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // Displays the Post for Delete view
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ds.Remove(id);
            return RedirectToAction("Index");
        }

        // Handles dispose
        protected override void Dispose(bool disposing)
        {
            ds.Dispose();
            base.Dispose(disposing);
        }
    }
}