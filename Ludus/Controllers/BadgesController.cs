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
    public class BadgesController : Controller
    {
        private DataServices.BadgesService ds = new DataServices.BadgesService();
        private DataContext dc = new DataContext();

        //View the badges, but also ensure we have the accurate and correct userID viewing the appropriate badges
        public ActionResult Index()
        {
            ViewBag.Label = "View Badges";
            return View(ds.Get(WebSecurity.CurrentUserId));
        }
        // Update the views and get the updated view, once again ensuring accurate security
        public ActionResult DView()
        {
            return View(ds.Get(WebSecurity.CurrentUserId));
        }
        
        //Load the details of specified badge
        public ActionResult Details(int id = 0, bool goHome = false)
        {
            Badge badge = ds.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            ViewBag.goHome = goHome;
            return View(badge);
        }

        // Load the view that will go to create a badge page
        public ActionResult Create()
        {
            return View();
        }

 
        //Create a badge and return to the primary index to view it in the list.
        //Needs to be setup, so only appropriate user can create badges.
        [HttpPost]
        public ActionResult Create(Badge badge)
        {
            if (ModelState.IsValid)
            {
                badge.Id = WebSecurity.CurrentUserId;//User.Identity
                ds.Create(badge);
                return RedirectToAction("Index");
            }

            return View(badge);
        }

        //Edit an existing badge page submission
        //Needs security for appropriate user to edit badges, students shouldnt be able to edit them.
        public ActionResult Edit(int id = 0, bool goHome = false)
        {
            Badge badge = ds.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            ViewBag.goHome = goHome;
            return View(badge);
        }

        //Edit an existing badge
        //Needs security for appropriate user to edit badges, students shouldnt be able to edit them.
        [HttpPost]
        public ActionResult Edit(Badge badge)
        {
            if (ModelState.IsValid)
            {
                ds.Update(badge);
                return RedirectToAction("Index");
            }
            return View(badge);
        }

        //delete an existing badge
        //Needs security for appropriate user to delete badges, students shouldnt be able to delete them.
        public ActionResult Delete(int id = 0)
        {
            Badge badge = ds.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            return View(badge);
        }

        //delete an existing badge confirmation
        //Needs security for appropriate user to delete badges, students shouldnt be able to delete them.
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