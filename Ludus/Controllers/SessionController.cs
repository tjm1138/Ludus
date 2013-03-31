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
    public class SessionController : Controller
    {
        private DataServices.SessionService ds = new DataServices.SessionService();
        private DataContext dc = new DataContext();
       
        // GET: /Session/
        public ActionResult Index()
        {
            ViewBag.Label = "Sessions";
            return View(ds.DisplaySessions());
        }
        
        // GET: /Session/Create

        public ActionResult Create()
        {
            return View();
        }

   
        // POST: /Session/Create

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

        // GET: /Session/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Session session = ds.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        // POST: /Session/Edit/5

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

        // GET: /Session/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Session session = ds.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        // POST: /Session/Delete/5

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