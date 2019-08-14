using Gazayerli_Task.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace Gazayerli_Task.Controllers
{
    //[Anonymous]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public AdminController()
        {
            db = new ApplicationDbContext();
        }


        public ActionResult GetLawyers()
        {
            return View(db.Lawyers.Include(a => a.ApplicationUser).ToList());
        }


        // GET: Admin
        [HttpGet]
        public ActionResult AddLawyer()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddLawyer(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
               // var newUser = new ApplicationUser { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email };
                var newUser = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Address = model.Address };

                var result = await UserManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    Lawyer newLawyer = new Lawyer { Id = newUser.Id, CostPerHour = 0 };
                    db.Lawyers.Add(newLawyer);
                    db.SaveChanges();

                    await UserManager.AddToRoleAsync(newUser.Id, MyCustomRoles.Lawyer);

                    return RedirectToAction("GetLawyers", "Admin");
                }
            }
            

            return View(model);
        }

        public ActionResult Delete(string Id)
        {
            db.Lawyers.Remove(db.Lawyers.Single(m => m.Id == Id));
            db.Users.Remove(db.Users.Single(u => u.Id == Id));
            db.SaveChanges();

            return RedirectToAction("GetLawyers");
        }


        public ActionResult Edit(string Id)
        {
            Session.Add("id", Id);
            
            return View(db.Users.Single(u => u.Id == Id));
        }
        [HttpPost]
        public ActionResult Edit(RegisterViewModel model)
        {
            string id = Session["id"].ToString();
            ApplicationUser olduser = db.Users.Single(us => us.Id == id);
            if (!ModelState.IsValid)
            {
                olduser.FirstName = model.FirstName;
                olduser.LastName = model.LastName;
                olduser.Address = model.Address;
            }
            db.SaveChanges();

            return RedirectToAction("GetLawyers");

        }


        public ActionResult Details (string id)
        {
            return View(db.Lawyers.Include(l => l.ApplicationUser).Single(ll=> ll.Id == id));
        }


        [HttpGet]
        public ActionResult AssignToCase (string id)
        {
            var lawyer = db.Lawyers.Single(l => l.Id == id);
            ViewBag.lawyer = lawyer;
            ViewBag.cases = new SelectList(db.Cases.ToList(), "CaseID", "CaseName");

           
            return View(new LawyerCases());
        }

      

        [HttpPost]
        public ActionResult AssignToCase(LawyerCases lawyerCase, string Id, int caseID)
        {
            Lawyer ll = db.Lawyers.Single(l => l.Id == Id);

            if (ModelState.IsValid) {
                var newLawyerCase = new LawyerCases()
                {
                    LawyerID = Id,
                    CaseID = caseID,
                    AssignDate = DateTime.Now
                };
                db.LawerCases.Add(newLawyerCase);
                db.SaveChanges();

            }
            else
            {
                ViewBag.msg = "Case is not available";
                return PartialView("message");
            }

            return RedirectToAction("GetLawyerCase");
        }

        public ActionResult Expired(string LawyerID, int CaseID)
        {
            
            LawyerCases lc = db.LawerCases.Single(x => x.CaseID == CaseID && x.LawyerID == LawyerID);

            if (ModelState.IsValid)
            {

                lc.ExpiredDate = DateTime.Now;
                db.SaveChanges();

                return RedirectToAction("GetLawyerCase");
            }
            else
            {
                ViewBag.msg = "Something Goes Wrong";
                return PartialView("message");
            }
            
        }

        [HttpGet]
        public ActionResult Bill(string LawyerID, int CaseID)
        {
            Lawyer lawyer = db.Lawyers.Single(b => b.Id == LawyerID);
            ViewBag.lawyer = lawyer;

            Cases caseName = db.Cases.Single(m => m.CaseID == CaseID);
            ViewBag.caseName = caseName;

            LawyerCases lc = db.LawerCases.Single(a => a.CaseID == CaseID && a.LawyerID == LawyerID); 

            int Starthours = lc.AssignDate.Hour;
            int Endhours = lc.ExpiredDate.Hour;



            int CostPerHour = lc.Lawyer.CostPerHour;
            int Duration = Endhours - Starthours;

            int total = CostPerHour * Duration;

            if (ModelState.IsValid)
            {

                lc.TotalHours = Duration;

                db.SaveChanges();

            }



            ViewBag.total = total;

            return View("Bill", lc);
        }

       


        [AllowAnonymous]
        public ActionResult GetLawyerCase()
        {
            var LawyerCases = db.LawerCases.Include(b => b.Case).Include(b => b.Lawyer);
            return View(LawyerCases.ToList());
        }
    }
}