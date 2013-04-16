/*
StudentController - Controls interactions between views in the Student folder and models.
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
    public class StudentController : Controller
    {
        private DataServices.StudentService ds = new DataServices.StudentService();
        private DataContext dc = new DataContext();

        // Retrieves a list of students from StudentService
        public ActionResult Index()
        {
            ViewBag.Label = "Students";
            return View(ds.DisplayStudents());
        }

        // Displays the Create view
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

        // Displays the Post for Create view
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

        // Displays the Edit view
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

        // Displays the Post for Edit view
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

        // Displays the Delete view
        public ActionResult Delete(int id = 0)
        {
            Student student = ds.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // Displays the Post for Delete view
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ds.Remove(id);
            return RedirectToAction("Index");
        }

        // Handles dispose
        protected override void Dispose(bool disposing)
        {
            ds.Dispose();
            base.Dispose(disposing);
        }
    }
}