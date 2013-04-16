/*
SectionController - Controls interactions between views in the Section folder and models.
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
    public class SectionController : Controller
    {
        private DataServices.SectionService ds = new DataServices.SectionService();
        private DataContext dc = new DataContext();

        // Retrieves a list of sections from SectionService
        public ActionResult Index()
        {
            ViewBag.Label = "Sections";
            return View(ds.DisplaySections());
        }

        // Displays the Create view
        public ActionResult Create()
        {
            // query users to a list
            var courseResults = (from c in dc.Courses
                               select c).ToList();

            // query sessions to a list
            var sessionResults = (from s in dc.Sessions
                                  select s).ToList();

            // populate user list to drop down menu
            IEnumerable<SelectListItem> courses;
            courses = courseResults.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            });

            // populate session list to drop down menu
            IEnumerable<SelectListItem> sessions;
            sessions = sessionResults.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            });

            ViewBag.CourseList = courses;       // set course list to ViewBag
            ViewBag.SessionList = sessions; // set session list to View Bag
            return View();

        }

        // Displays the Post for Create view
        [HttpPost]
        public ActionResult Create(Section section)
        {
            if (ModelState.IsValid)
            {
                ds.Create(section);
                return RedirectToAction("Index");
            }

            return View(section);
        }

        // Displays the Edit view
        public ActionResult Edit(int id = 0)
        {
            Section Section = ds.Find(id);
            if (Section == null)
            {
                return HttpNotFound();
            }

            // query users to a list
            var courseResults = (from c in dc.Courses
                               select c).ToList();

            // query sessions to a list
            var sessionResults = (from s in dc.Sessions
                                  select s).ToList();

            // populate user list to drop down menu
            IEnumerable<SelectListItem> courses;
            courses = courseResults.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            });

            // populate session list to drop down menu
            IEnumerable<SelectListItem> sessions;
            sessions = sessionResults.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            });

            var model = new Section();
            model.Id = id;
            //ViewBag.SessionId = new SelectList(sessions, "Value", "Text", Section.SessionId);
            ViewBag.CourseList = courses;       // set user list to ViewBag
            ViewBag.SessionList = sessions; // set session list to View Bag
            return View(model);
        }

        // Displays the Post for Edit view
        [HttpPost]
        public ActionResult Edit(Section section)
        {
            if (ModelState.IsValid)
            {
                ds.Update(section);
                return RedirectToAction("Index");
            }
            return View(section);
        }

        // Displays the Delete view
        public ActionResult Delete(int id = 0)
        {
            Section section = ds.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
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