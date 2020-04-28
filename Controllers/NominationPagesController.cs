using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Centric_Consulting_MIS_4200_Project.DAL;
using Centric_Consulting_MIS_4200_Project.Models;

namespace Centric_Consulting_MIS_4200_Project.Controllers
{
    public class NominationPagesController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: NominationPages
        public ActionResult Index()
        {
            return View(db.NominationPages.ToList());
        }

        // GET: NominationPages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominationPage nominationPage = db.NominationPages.Find(id);
            if (nominationPage == null)
            {
                return HttpNotFound();
            }
            return View(nominationPage);
        }

        // GET: NominationPages/Create
        [Authorize]
        public ActionResult Create()
        {
            string PID = User.Identity.GetUserId();
            SelectList profiles = new SelectList(db.Profiles, "PID", "fullName");
            profiles = new SelectList(profiles.Where(x => x.Value != PID).ToList(), "Value", "Text");
            ViewBag.PID = new SelectList(db.Profiles, "PID", "fullName");
            //var profiles = db.Profiles.OrderBy(c => c.lastName).ThenBy(c => c.firstName);
            return View();
        }

        // POST: NominationPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PID,award,recognizor,recognized,recognizationDate")] NominationPage nominationPage)
        {
            if (ModelState.IsValid)
            {
                db.NominationPages.Add(nominationPage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nominationPage);
        }

        // GET: NominationPages/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominationPage nominationPage = db.NominationPages.Find(id);
            if (nominationPage == null)
            {
                return HttpNotFound();
            }
            return View(nominationPage);
        }

        // POST: NominationPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PID,award,recognizor,recognized,recognizationDate")] NominationPage nominationPage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nominationPage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nominationPage);
        }

        // GET: NominationPages/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominationPage nominationPage = db.NominationPages.Find(id);
            if (nominationPage == null)
            {
                return HttpNotFound();
            }
            return View(nominationPage);
        }

        // POST: NominationPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NominationPage nominationPage = db.NominationPages.Find(id);
            db.NominationPages.Remove(nominationPage);
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
