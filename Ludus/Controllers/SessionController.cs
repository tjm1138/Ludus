/*
SessionController - Controls interactions between views in the Session folder and models.
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
    public class SessionController : Controller
    {
        private DataServices.SessionService ds = new DataServices.SessionService();
        private DataContext dc = new DataContext();

        // Retrieves a list of sessions from SessionService
        public ActionResult Index()
        {
            ViewBag.Label = "Sessions";
            return View(ds.DisplaySessions());
        }

        // Displays the Create view
        public ActionResult Create()
        {
            return View();
        }


        // Displays the Post for Create view
        [HttpPost]
        public ActionResult Create(Session session)
        {
            if (ModelState.IsValid)
            {
                ds.Create(session);
                return RedirectToAction("Index");
            }

            return View(session);
        }

        // Displays the Edit view
        public ActionResult Edit(int id = 0)
        {
            Session session = ds.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        // Displays the Post for Edit view
        [HttpPost]
        public ActionResult Edit(Session session)
        {
            if (ModelState.IsValid)
            {
                ds.Update(session);
                return RedirectToAction("Index");
            }
            return View(session);
        }

        // Displays the Delete view
        public ActionResult Delete(int id = 0)
        {
            Session session = ds.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        // Displays the Post for Delete view
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ds.Remove(id);
            return RedirectToAction("Index");
        }

        // Handles dispose method
        protected override void Dispose(bool disposing)
        {
            ds.Dispose();
            base.Dispose(disposing);
        }
    }
}