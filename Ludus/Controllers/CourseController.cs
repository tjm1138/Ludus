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
    public class CourseController : Controller
    {
        private DataServices.CourseService ds = new DataServices.CourseService();
        private DataContext dc = new DataContext();

        // GET: /Course/
        public ActionResult Index()
        {
            ViewBag.Label = "Courses";
            return View(ds.DisplayCourses());
        }

        // GET: /Course/Create

        public ActionResult Create()
        {
            return View();
        }


        // POST: /Course/Create

        [HttpPost]
        public ActionResult Create(Course Course)
        {
            if (ModelState.IsValid)
            {
                ds.Create(Course);
                return RedirectToAction("Index");
            }

            return View(Course);
        }

        // GET: /Course/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Course Course = ds.Find(id);
            if (Course == null)
            {
                return HttpNotFound();
            }
            return View(Course);
        }

        // POST: /Course/Edit/5

        [HttpPost]
        public ActionResult Edit(Course Course)
        {
            if (ModelState.IsValid)
            {
                ds.Update(Course);
                return RedirectToAction("Index");
            }
            return View(Course);
        }

        // GET: /Course/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Course Course = ds.Find(id);
            if (Course == null)
            {
                return HttpNotFound();
            }
            return View(Course);
        }

        // POST: /Course/Delete/5

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