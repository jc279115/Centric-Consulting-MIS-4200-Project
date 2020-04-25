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

namespace Centric_Consulting_MIS_4200_Project.Controllers
{
    public class LeaderboardsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: Leaderboards
        [Authorize]
        public ActionResult Index()
        {
            var leaderboards = db.Leaderboards.Include(l => l.Profile);
            return View(leaderboards.ToList());
        }

        // GET: Leaderboards/Details/5
        [Authorize]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leaderboard leaderboard = db.Leaderboards.Find(id);
            if (leaderboard == null)
            {
                return HttpNotFound();
            }
            return View(leaderboard);
        }

        // GET: Leaderboards/Create
        public ActionResult Create()
        {
            ViewBag.PID = new SelectList(db.Profiles, "PID", "firstName");
            return View();
        }

        // POST: Leaderboards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PID,lastName,Date")] Leaderboard leaderboard)
        {
            if (ModelState.IsValid)
            {
                leaderboard.PID = Guid.NewGuid();
                db.Leaderboards.Add(leaderboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PID = new SelectList(db.Profiles, "PID", "firstName", leaderboard.PID);
            return View(leaderboard);
        }

        // GET: Leaderboards/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leaderboard leaderboard = db.Leaderboards.Find(id);
            if (leaderboard == null)
            {
                return HttpNotFound();
            }
            ViewBag.PID = new SelectList(db.Profiles, "PID", "firstName", leaderboard.PID);
            return View(leaderboard);
        }

        // POST: Leaderboards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PID,lastName,Date")] Leaderboard leaderboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaderboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PID = new SelectList(db.Profiles, "PID", "firstName", leaderboard.PID);
            return View(leaderboard);
        }

        // GET: Leaderboards/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leaderboard leaderboard = db.Leaderboards.Find(id);
            if (leaderboard == null)
            {
                return HttpNotFound();
            }
            return View(leaderboard);
        }

        // POST: Leaderboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Leaderboard leaderboard = db.Leaderboards.Find(id);
            db.Leaderboards.Remove(leaderboard);
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
