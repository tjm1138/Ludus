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
    public class AssignmentController : Controller
    {
        private DataServices.AssignmentService ds = new DataServices.AssignmentService();
        private DataContext dc = new DataContext();

        // GET: /Assignment/
        public ActionResult Index()
        {
            ViewBag.Label = "Assignments";
            return View(ds.DisplayAssignments());
            //return View();
        }

        //// GET: /Assignment/Create

        //public ActionResult Create()
        //{
        //    // query users to a list
        //    var userResults = (from u in dc.UserProfiles
        //                       select u).ToList();

        //    // query sessions to a list
        //    var sessionResults = (from s in dc.Sessions
        //                          select s).ToList();

        //    // populate user list to drop down menu
        //    IEnumerable<SelectListItem> users;
        //    users = userResults.Select(a => new SelectListItem
        //    {
        //        Value = a.UserId.ToString(),
        //        Text = a.UserName
        //    });

        //    // populate session list to drop down menu
        //    IEnumerable<SelectListItem> sessions;
        //    sessions = sessionResults.Select(a => new SelectListItem
        //    {
        //        Value = a.Id.ToString(),
        //        Text = a.Name
        //    });

        //    ViewBag.UserList = users;       // set user list to ViewBag
        //    ViewBag.SessionList = sessions; // set session list to View Bag
        //    return View();

        //}

        //// POST: /Assignment/Create

        //[HttpPost]
        //public ActionResult Create(Assignment Assignment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ds.Create(Assignment);
        //        return RedirectToAction("Index");
        //    }

        //    return View(Assignment);
        //}

        //// GET: /Assignment/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Assignment Assignment = ds.Find(id);
        //    if (Assignment == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    // query users to a list
        //    var userResults = (from u in dc.UserProfiles
        //                       select u).ToList();

        //    // query sessions to a list
        //    var sessionResults = (from s in dc.Sessions
        //                          select s).ToList();

        //    // populate user list to drop down menu
        //    IEnumerable<SelectListItem> users;
        //    users = userResults.Select(a => new SelectListItem
        //    {
        //        Value = a.UserId.ToString(),
        //        Text = a.UserName
        //    });

        //    // populate session list to drop down menu
        //    IEnumerable<SelectListItem> sessions;
        //    sessions = sessionResults.Select(a => new SelectListItem
        //    {
        //        Value = a.Id.ToString(),
        //        Text = a.Name
        //    });

        //    var model = new Assignment();
        //    model.UserId = id;
        //    ViewBag.SessionId = new SelectList(sessions, "Value", "Text", Assignment.SessionId);
        //    ViewBag.UserList = users;       // set user list to ViewBag
        //    ViewBag.SessionList = sessions; // set session list to View Bag
        //    return View(model);
        //}

        //// POST: /Assignment/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Assignment Assignment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ds.Update(Assignment);
        //        return RedirectToAction("Index");
        //    }
        //    return View(Assignment);
        //}

        // GET: /Assignment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Assignment Assignment = ds.Find(id);
            if (Assignment == null)
            {
                return HttpNotFound();
            }
            return View(Assignment);
        }

        // POST: /Assignment/Delete/5

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