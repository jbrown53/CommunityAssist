using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist.Models;

namespace CommunityAssist.Controllers
{
    public class GrantApplicationsController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: GrantApplications
        public ActionResult Index()
        {
            if(Session["personKey"] == null)
            {
                Message m = new Message("You must be logged in to perform this action");
                return RedirectToAction("Result", m);
            }

            ViewBag.GrantTypes = new SelectList(db.GrantTypes, "GrantTypeKey", "GrantTypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonKey, GrantApplicationDate, GrantTypeKey, GrantApplicationRequestAmount, GrantApplicationReason, GrantApplicationStatusKey", Exclude ="GrantApplicationAllocationAmount")]GrantApplication ga)
        {
            ga.PersonKey = (int)Session["personKey"];
            ga.GrantAppicationDate = DateTime.Now;
            ga.GrantApplicationStatusKey = 1;
            db.GrantApplications.Add(ga);
            db.SaveChanges();

            return View("Result", new Message("Thanks for your application.  We will get back to you as soon as possible."));
        }

        public ActionResult Result(Message message)
        {
            return View(message);
        }
    }
}
