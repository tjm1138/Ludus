﻿/*
 * Home Controller - Controls interactions between views in the Home folder and models 
 * Thomas Moseley
 * May 31, 2013
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
    // Filters is required for the InitializeSimpleMembership attribute, necessary to interact with 
    // the membership system.
    using Ludus.Filters;
    // Models are data structures on which the code runs.
    using Ludus.Models;
    // Contains the Membership system
    using WebMatrix.WebData;

    // This attribute, coded in Ludus.Filters, initializes the Membership system for inquiries, such 
    // as WebSecurity.CurrentUserId
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        private DataServices.CalendarService cs = new DataServices.CalendarService();
        public ActionResult Index()
        {
            if (Session["IndexView"] == null)
                Session["IndexView"] = "Month";
            //ViewBag.View = "Month";
            // Retrieves the calendar entries for the current user, and feeds them to the view.
            DataServices.CalendarService cs = new DataServices.CalendarService();
            return View(cs.Find(WebSecurity.CurrentUserId));
        }

        //[HttpPost, ActionName("Month")]
        //public ActionResult Index(Calendar calendar)
        //{
        //    ViewBag.View = "Month";
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public ActionResult Index(Calendar calendar)
        {
            if (Session["IndexView"] == "Month")
                Session["IndexView"] = "List";
            else
                Session["IndexView"] = "Month";
            return RedirectToAction("Index");
        }
        public ActionResult Documents()
        {
            // Static Page, at the moment, so no data retrieval necessary.
            // TODO: Create Documents management page.
            ViewBag.Message = "Your documents";
            return View();
        }

        public ActionResult About()
        {
            // Static Page, so no data retrieval necessary.
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
