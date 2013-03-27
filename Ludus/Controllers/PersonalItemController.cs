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
    public class PersonalItemController : Controller
    {
        private DataServices.PersonalItemService ds = new DataServices.PersonalItemService();
        private DataContext dc = new DataContext();
        //
        // GET: /PersonalIItem/
        public ActionResult Index()
        {
            ViewBag.Label = "View Personal Items";
            return View(ds.MyItems());
        }
        // GET: /PersonalIItem/
        public ActionResult DayView()
        {
            return View(ds.MyItems());
        }

        //
        // GET: /PersonalIItem/Details/5

        public ActionResult Details(int id = 0)
        {
            PersonalItem personalitem = ds.Find(id);
            if (personalitem == null)
            {
                return HttpNotFound();
            }
            return View(personalitem);
        }

        //
        // GET: /PersonalIItem/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PersonalIItem/Create

        [HttpPost]
        public ActionResult Create(PersonalItem personalitem)
        {
            if (ModelState.IsValid)
            {
                personalitem.UserId = 5;//User.Identity
                ds.Create(personalitem);
                return RedirectToAction("Index");
            }

            return View(personalitem);
        }

        //
        // GET: /PersonalIItem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PersonalItem personalitem = ds.Find(id);
            if (personalitem == null)
            {
                return HttpNotFound();
            }
            return View(personalitem);
        }

        //
        // POST: /PersonalIItem/Edit/5

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