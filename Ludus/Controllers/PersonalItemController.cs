/*
 * Personal Item Controller - Controls interactions between views in the Personal Item folder and models 
 * Thomas Moseley
 * April 17, 2013
*/

namespace Ludus.Controllers
{
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
    [InitializeSimpleMembership]
    public class PersonalItemController : Controller
    {
        private DataServices.PersonalItemService ds = new DataServices.PersonalItemService();
        //
        // GET: /PersonalIItem/
        // Shows all of Personal Items for the current user. 
        public ActionResult Index()
        {
            ViewBag.Label = "View Personal Items";
            return View(ds.Get(WebSecurity.CurrentUserId));
        }

        //
        // GET: /PersonalIItem/Details/5
        // Show the details of a single Personal Item
        public ActionResult Details(int id = 0, bool goHome = false)
        {
            PersonalItem personalitem = ds.Find(id);
            if (personalitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.goHome = goHome;
            return View(personalitem);
        }

        //
        // GET: /PersonalIItem/Create
        // Provides a blank for adding one.
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PersonalIItem/Create
        // After editing is done on a new one, adds it to the database
        [HttpPost]
        public ActionResult Create(PersonalItem personalitem)
        {
            if (ModelState.IsValid)
            {
                // This is for the current user
                personalitem.UserId = WebSecurity.CurrentUserId;//User.Identity
                ds.Create(personalitem);
                // Send us back to the list view
                return RedirectToAction("Index");
            }

            return View(personalitem);
        }

        //
        // GET: /PersonalIItem/Edit/5
        // We're editing, so we need to look up the current item and show the edit screen
        // goHome is used when we want to go back to the home page
        public ActionResult Edit(int id = 0, bool goHome = false)
        {
            PersonalItem personalitem = ds.Find(id);
            if (personalitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.goHome = goHome;
            return View(personalitem);
        }

        //
        // POST: /PersonalIItem/Edit/5
        // Now that editing is complete, save the changes.
        [HttpPost]
        public ActionResult Edit(PersonalItem personalitem)
        {
            if (ModelState.IsValid)
            {
                ds.Update(personalitem);
                return RedirectToAction("Index");
            }
            return View(personalitem);
        }

        //
        // GET: /PersonalIItem/Delete/5
        // Show the form for deletion
        public ActionResult Delete(int id = 0)
        {
            PersonalItem personalitem = ds.Find(id);
            if (personalitem == null)
            {
                return HttpNotFound();
            }
            return View(personalitem);
        }

        //
        // POST: /PersonalIItem/Delete/5
        // Deletion Confirmed, do it and go back to the index.
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ds.Remove(id);
            return RedirectToAction("Index");
        }
        // from IDisposable, to release memory from the Service.
        protected override void Dispose(bool disposing)
        {
            ds.Dispose();
            base.Dispose(disposing);
        }
    }
}