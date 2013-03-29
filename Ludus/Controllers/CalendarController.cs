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
    public class CalendarController : Controller
    {
        private DataServices.CalendarService cs = new DataServices.CalendarService();
        public ActionResult Index()
        {
            ViewBag.Label = "View Personal Items";
            return View(cs.Get(WebSecurity.CurrentUserId));
        }
        public ActionResult DayView()
        {
            return View(cs.Get(WebSecurity.CurrentUserId));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}