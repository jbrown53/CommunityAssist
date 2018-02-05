using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist.Models;

namespace CommunityAssist.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonLastName, PersonFirstName, PersonEmail, PersonPassword, PersonAddressApt, PersonAddressStreet, PersonAddressCity, PersonAddressState, PersonAddressPostal, PersonPrimaryPhone")]NewPerson np)
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();

            int registerResult = db.usp_Register(np.PersonLastName, np.PersonFirstName, np.PersonEmail, np.PersonPassword, np.PersonAddressApt, np.PersonAddressStreet, np.PersonAddressCity, np.PersonAddressState, np.PersonAddressPostal, np.PersonPrimaryPhone);

            Message message = new Message();
            message.MessageText = registerResult != -1 ? "Register success!" : "Something wrong!";

            return View("Result", message);
        }

        public ActionResult Result(Message msg)
        {
            return View(msg);
        }
    }
}