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
    public class HomeController : Controller
    {
        private DataServices.CalendarService cs = new DataServices.CalendarService();
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application, yo.";

            return View(cs.Get(WebSecurity.CurrentUserId));
        }
        public ActionResult Documents()
        {
            ViewBag.Message = "Your documents";

            return View();

        }
        // GET: /PersonalIItem/
        public ActionResult DayView()
        {
            using (DataServices.PersonalItemService ds = new DataServices.PersonalItemService())
            {
                return View(cs.Get(WebSecurity.CurrentUserId));
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            cs.Dispose();
            base.Dispose(disposing);
        }
 
    }
}
