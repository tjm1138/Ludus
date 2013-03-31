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

        // get Badges
        public ActionResult Index()
        {
            ViewBag.Label = "View Badges";
            return View(ds.Get(WebSecurity.CurrentUserId));
        }
        // GET: /Badge/
        public ActionResult DayView()
        {
            return View(ds.Get(WebSecurity.CurrentUserId));
        }

        //
        // GET: /Badge/Details/5

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

        //
        // GET: /Badge/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Badge/Create

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

        //
        // GET: /Badge/Edit/5

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

        //
        // POST: /Badge/Edit/5

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

        //
        // GET: /Badge/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Badge badge = ds.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            return View(badge);
        }

        //
        // POST: /Badge/Delete/5

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