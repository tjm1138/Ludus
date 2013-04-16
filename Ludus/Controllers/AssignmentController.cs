/*
AssignmentController - Controls interactions between views in the Assignment folder and models.
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
    public class AssignmentController : Controller
    {
        private DataServices.AssignmentService ds = new DataServices.AssignmentService();
        private DataContext dc = new DataContext();

        // Retrieves a list of assignments from AssignmentService
        public ActionResult Index()
        {
            ViewBag.Label = "Assignments";
            return View(ds.DisplayAssignments());
            //return View();
        }

        // Displays the Create view
        public ActionResult Create()
        {
            return View();
        }


        // Displays the Post for Create view
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

        // Displays the Edit view
        public ActionResult Edit(int id = 0)
        {
            Assignment assignment = ds.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // Displays the Post for Edit view
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

        // Displays the Delete view
        public ActionResult Delete(int id = 0)
        {
            Assignment assignment = ds.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
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