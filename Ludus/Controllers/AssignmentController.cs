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

        public ActionResult Create()
        {
            return View();
        }


        // POST: /Assignment/Create

        [HttpPost]
        public ActionResult Create(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                ds.Create(assignment);
                return RedirectToAction("Index");
            }

            return View(assignment);
        }

        // GET: /Assignment/Edit/

        public ActionResult Edit(int id = 0)
        {
            Assignment assignment = ds.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // POST: /Assignment/Edit/

        [HttpPost]
        public ActionResult Edit(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                ds.Update(assignment);
                return RedirectToAction("Index");
            }
            return View(assignment);
        }

        // GET: /Assignment/Delete/

        public ActionResult Delete(int id = 0)
        {
            Assignment assignment = ds.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // POST: /Assignment/Delete/

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