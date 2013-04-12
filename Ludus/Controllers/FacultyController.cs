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
    [InitializeSimpleMembership]
    public class FacultyController : Controller
    {
        private DataServices.FacultyService ds = new DataServices.FacultyService();
        private DataContext dc = new DataContext();

        // GET: /Faculty/
        public ActionResult Index()
        {
            ViewBag.Label = "Facultys";
            return View(ds.DisplayFaculties());
            //return View();
        }

        // GET: /Faculty/Create

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

        // POST: /Faculty/Create

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

        // GET: /Faculty/Edit/5

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

        // POST: /Faculty/Edit/5

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

        // GET: /Faculty/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Faculty Faculty = ds.Find(id);
            if (Faculty == null)
            {
                return HttpNotFound();
            }
            return View(Faculty);
        }

        // POST: /Faculty/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ds.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            ds.Dispose();
            base.Dispose(disposing);
        }
    }
}