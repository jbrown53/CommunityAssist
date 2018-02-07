using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist.Models;

namespace CommunityAssist.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Email, Password")]LoginClass lc)
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            Message message = new Message("Message not set.");

            int loginresult = db.usp_Login(lc.Email, lc.Password);

            if(loginresult != -1)
            {
                var uid = (from p in db.People
                           where p.PersonEmail.Equals(lc.Email)
                           select p.PersonKey).FirstOrDefault();
                int pKey = (int)uid;

                Session["personKey"] = pKey;
                message.MessageText = "You're logged in, " + lc.Email + ".";

                return RedirectToAction("Result", message);
            }

            message.MessageText = "Something went wrong with the login.";
            return View("Result", message);
        }

        public ActionResult Result(Message m)
        {
            return View("Result", m);
        }
    }
}