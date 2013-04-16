/*
FacultyController - Controls interactions between views in the Faculty folder and models.
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
    public class FacultyController : Controller
    {
        private DataServices.FacultyService ds = new DataServices.FacultyService();
        private DataContext dc = new DataContext();

        // Retrieves a list of faculty members from FacultyService
        public ActionResult Index()
        {
            ViewBag.Label = "Facultys";
            return View(ds.DisplayFaculties());
            //return View();
        }

        // Displays the Create view
        public ActionResult Create()
        {
            // query users to a list
            var userResults = (from u in dc.UserProfiles
                               select u).ToList();

            // query sessions to a list
            var sessionResults = (from s in dc.Sessions
                                  select s).ToList();

            // populate user list to drop down menu
            IEnumerable<SelectListItem> users;
            users = userResults.Select(a => new SelectListItem
            {
                Value = a.UserId.ToString(),
                Text = a.UserName
            });

            // populate session list to drop down menu
            IEnumerable<SelectListItem> sessions;
            sessions = sessionResults.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            });

            ViewBag.UserList = users;       // set user list to ViewBag
            ViewBag.SessionList = sessions; // set session list to View Bag
            return View();

        }

        // Displays the Post for Create view
        [HttpPost]
        public ActionResult Create(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                ds.Create(faculty);
                return RedirectToAction("Index");
            }

            return View(faculty);
        }

        // Displays the Edit view
        public ActionResult Edit(int id = 0)
        {
            Faculty Faculty = ds.Find(id);
            if (Faculty == null)
            {
                return HttpNotFound();
            }

            // query users to a list
            var userResults = (from u in dc.UserProfiles
                               select u).ToList();

            // query sessions to a list
            var sessionResults = (from s in dc.Sessions
                                  select s).ToList();

            // populate user list to drop down menu
            IEnumerable<SelectListItem> users;
            users = userResults.Select(a => new SelectListItem
            {
                Value = a.UserId.ToString(),
                Text = a.UserName
            });

            // populate session list to drop down menu
            IEnumerable<SelectListItem> sessions;
            sessions = sessionResults.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            });

            var model = new Faculty();
            model.UserId = id;
            ViewBag.SessionId = new SelectList(sessions, "Value", "Text", Faculty.SessionId);
            ViewBag.UserList = users;       // set user list to ViewBag
            ViewBag.SessionList = sessions; // set session list to View Bag
            return View(model);
        }

        // Displays the Post for Edit view
        [HttpPost]
        public ActionResult Edit(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                ds.Update(faculty);
                return RedirectToAction("Index");
            }
            return View(faculty);
        }

        // Displays the Delete view
        public ActionResult Delete(int id = 0)
        {
            Faculty Faculty = ds.Find(id);
            if (Faculty == null)
            {
                return HttpNotFound();
            }
            return View(Faculty);
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