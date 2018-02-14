using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist.Models;

namespace CommunityAssist.Controllers
{
    public class DonateController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();

        // GET: Donate
        public ActionResult Index()
        {
            if(Session["personKey"] == null)
            {
                Message m = new Message("You must be logged in to perform this action");
                return RedirectToAction("Result", m);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Amount")]DonationClass dc)
        {
            decimal donationAmount = (decimal)dc.Amount;

            //create new donation
            Donation newDonation = new Donation();
            newDonation.DonationAmount = donationAmount;
            newDonation.PersonKey = (int)Session["personKey"];
            newDonation.DonationDate = DateTime.Now;
            newDonation.DonationConfirmationCode = Guid.NewGuid();

            //save new donation
            db.Donations.Add(newDonation);
            db.SaveChanges();

            //get thank you message, display result
            Message msg = new Message("Thank you for your donation of $" + donationAmount.ToString() + ".  Have a good day.");
            return View("Result", msg);
        }

        public ActionResult  Result(Message message)
        {
            return View(message);
        }
    }
}
