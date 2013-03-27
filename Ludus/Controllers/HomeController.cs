using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ludus.Filters;
namespace Ludus.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        private DataServices.PersonalItemService ds = new DataServices.PersonalItemService();
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application, yo.";

            return View(ds.MyItems());
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
                return View(ds.MyItems());
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
            ds.Dispose();
            base.Dispose(disposing);
        }
 
    }
}
