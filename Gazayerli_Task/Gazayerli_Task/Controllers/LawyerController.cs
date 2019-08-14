using Gazayerli_Task.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gazayerli_Task.Controllers
{
    [Authorize(Roles = "Lawyer")]

    public class LawyerController : Controller
    {
        private ApplicationDbContext db;

        public LawyerController()
        {
            db = new ApplicationDbContext();

        }
        // GET: Lawyer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowProfile()
        {
            string id = User.Identity.GetUserId();
            var laywer = db.Lawyers.Single(a => a.Id == id);
            return View(laywer);

        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            string Id = User.Identity.GetUserId();
            var laywer = db.Lawyers.Single(a => a.Id == Id);
            return PartialView(laywer);

        }


        [HttpPost]
        public ActionResult EditProfile(Lawyer _lawyer)
        {
            string Id = User.Identity.GetUserId();
            var OldLaywer = db.Lawyers.Single(a => a.Id == Id);
            if (ModelState.IsValid)
            {
                OldLaywer.CostPerHour = _lawyer.CostPerHour;
                OldLaywer.ApplicationUser.FirstName = _lawyer.ApplicationUser.FirstName;
                OldLaywer.ApplicationUser.LastName = _lawyer.ApplicationUser.LastName;
                OldLaywer.ApplicationUser.Address = _lawyer.ApplicationUser.Address;
                OldLaywer.ApplicationUser.UserName = _lawyer.ApplicationUser.UserName;
                OldLaywer.ApplicationUser.Email = _lawyer.ApplicationUser.Email;
            }
            db.SaveChanges();

            return RedirectToAction("ShowProfile");

        }



        //public ActionResult SetHour(int hour)
        //{
        //    string id = User.Identity.GetUserId();
        //    Lawyer olduser = db.Lawyers.SingleOrDefault(us => us.Id == id);

        //    olduser.CostPerHour = hour;

        //    db.SaveChanges();
        //    return RedirectToAction("ShowProfile");
        //}
    }
}