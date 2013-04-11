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
    public class SectionController : Controller
    {
        private DataServices.SectionService ds = new DataServices.SectionService();
        private DataContext dc = new DataContext();

        // GET: /Section/
        public ActionResult Index()
        {
            ViewBag.Label = "Sections";
            return View(ds.DisplaySections());
        }

        // GET: /Section/Create

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

        //// POST: /Section/Create

        //[HttpPost]
        //public ActionResult Create(Section section)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ds.Create(section);
        //        return RedirectToAction("Index");
        //    }

        //    return View(section);
        //}

        //// GET: /Section/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Section Section = ds.Find(id);
        //    if (Section == null)
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

        //    var model = new Section();
        //    model.UserId = id;
        //    ViewBag.SessionId = new SelectList(sessions, "Value", "Text", Section.SessionId);
        //    ViewBag.UserList = users;       // set user list to ViewBag
        //    ViewBag.SessionList = sessions; // set session list to View Bag
        //    return View(model);
        //}

        //// POST: /Section/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Section section)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ds.Update(section);
        //        return RedirectToAction("Index");
        //    }
        //    return View(section);
        //}

        // GET: /Section/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Section section = ds.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: /Section/Delete/5

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