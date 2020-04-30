using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Centric_Consulting_MIS_4200_Project.DAL;
using Centric_Consulting_MIS_4200_Project.Models;
using Microsoft.AspNet.Identity;

namespace Centric_Consulting_MIS_4200_Project.Controllers
{
    public class ProfilesController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: Profiles
        public ActionResult Index(string searchString)

 {
var testusers = from u in db.Profiles select u;

         if (!String.IsNullOrEmpty(searchString))
 {

 testusers = testusers.Where(u =>

u.lastName.Contains(searchString)

|| u.firstName.Contains(searchString));

// if here, users were found so view them

 return View(testusers.ToList());

         }

     return View(db.Profiles.ToList());

     }

 

        // GET: Profiles/Details/5
        [Authorize]
        public ActionResult Details(Guid? id)
        {
            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }

            var rec = db.NominationPages.Where(r => r.recognized == id);
            var recList = rec.ToList();
            ViewBag.rec = recList.ToList();
            var totalCnt = recList.Count(); //counts all the recognitions for that person
            var rec1Cnt = recList.Where(r => r.award == NominationPage.CoreValue.Excellence).Count();
            // counts all the Excellence recognitions
            // notice how the Enum values are references, class.enum.value
            // the next two lines show another way to do the same counting
            var rec2Cnt = recList.Count(r => r.award == NominationPage.CoreValue.Integrity);
            var rec3Cnt = recList.Count(r => r.award == NominationPage.CoreValue.Stewardship);
            var rec4Cnt = recList.Count(r => r.award == NominationPage.CoreValue.Culture);
            var rec5Cnt = recList.Count(r => r.award == NominationPage.CoreValue.Balance);
            var rec6Cnt = recList.Count(r => r.award == NominationPage.CoreValue.Innovation);
            var rec7Cnt = recList.Count(r => r.award == NominationPage.CoreValue.Lifestyle);

            // copy the values into the ViewBag
            ViewBag.total = totalCnt;
            ViewBag.Excellence = rec1Cnt;
            ViewBag.Integrity = rec2Cnt;
            ViewBag.Stewardship = rec3Cnt;
            ViewBag.Culture = rec4Cnt;
            ViewBag.Balance = rec5Cnt;
            ViewBag.Innovation = rec6Cnt;
            ViewBag.Lifestyle = rec7Cnt;

            return View(profile);
        }



        // GET: Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PID,firstName,lastName,phoneNumber,department,primaryOfficeLocation,jobTitle")] Profile profile)
        {


            if (ModelState.IsValid)
            {
                Guid PID;
                Guid.TryParse(User.Identity.GetUserId(), out PID);
                profile.email = User.Identity.Name;
                profile.PID = PID;
                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(profile);
        }

        // GET: Profiles/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile user = db.Profiles.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (user.PID == memberID)
            {
                return View(user);
            }
            else
            {
                return View("NotAuthenticated");
            }
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PID,firstName,lastName,email,phoneNumber,department,primaryOfficeLocation,jobTitle")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        //GET: Profiles/Delete/5
        [Authorize]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile user = db.Profiles.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (user.PID == memberID)
            {
                return View(user);
            }
            else
            {
                return View("NotAuthenticated");
            }
        }

        //POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
