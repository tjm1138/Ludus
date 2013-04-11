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
    public class StudentController : Controller
    {
        private DataServices.StudentService ds = new DataServices.StudentService();
        private DataContext dc = new DataContext();

        // GET: /Student/
        public ActionResult Index()
        {
            ViewBag.Label = "Students";
            return View(ds.DisplayStudents());
            //return View();
        }

        // GET: /Student/Create

        public ActionResult Create()
        {
            // query users to a list
            var userResults = (from u in dc.UserProfiles
                               select u).ToList();

            // query sessions to a list
            var sessionResults = (from s in dc.Sessions
                           select s).ToList();

            // populate user list to drop down menu
            IEnumerable<SelectListItem> users;
            users = userResults.Select(a => new SelectListItem
            {
                Value = a.UserId.ToString(),
                Text = a.UserName
            });

            // populate session list to drop down menu
            IEnumerable<SelectListItem> sessions;
            sessions = sessionResults.Select(a => new SelectListItem
                        {
                            Value = a.Id.ToString(),
                            Text = a.Name
                        });
                        
            ViewBag.UserList = users;       // set user list to ViewBag
            ViewBag.SessionList = sessions; // set session list to View Bag
            return View();

        }

        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                ds.Create(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: /Student/Edit/5

        public ActionResult Edit(int id)
        {
            Student student = ds.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            
            // query users to a list
            var userResults = (from u in dc.UserProfiles
                               select u).ToList();

            // query sessions to a list
            var sessionResults = (from s in dc.Sessions
                                  select s).ToList();

            // populate user list to drop down menu
            IEnumerable<SelectListItem> users;
            users = userResults.Select(a => new SelectListItem
            {
                Value = a.UserId.ToString(),
                Text = a.UserName
            });

            // populate session list to drop down menu
            IEnumerable<SelectListItem> sessions;
            sessions = sessionResults.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            });
            
            var model = new Student();
            model.UserId = id;
            ViewBag.SessionId = new SelectList(sessions, "Value", "Text", student.SessionId);  
            ViewBag.UserList = users;       // set user list to ViewBag
            ViewBag.SessionList = sessions; // set session list to View Bag
            return View(model);
        }

        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                ds.Update(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Student student = ds.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Delete/5

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