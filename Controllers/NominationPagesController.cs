using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Mail;
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
        [Authorize]
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
            ViewBag.recognizor = new SelectList(db.Profiles, "PID", "fullName");
            ViewBag.recognized = new SelectList(db.Profiles, "PID", "fullName");
            return View();
        }

        // POST: NominationPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PID,award,recognizor,recognized")] NominationPage nominationPage)
        {
            

            if (ModelState.IsValid)
            {
                nominationPage.recognizationDate = DateTime.Now;
                db.NominationPages.Add(nominationPage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            SmtpClient myClient = new SmtpClient();
            // the following line has to contain the email address and password of someone
            // authorized to use the email server (you will need a valid Ohio account/password
            // for this to work)
            myClient.Credentials = new NetworkCredential("AuthorizedUser", "UserPassword");
            MailMessage myMessage = new MailMessage();
            // the syntax here is email address, username (that will appear in the email)
            MailAddress from = new MailAddress("jc279115@ohio.edu", "SysAdmin");
            myMessage.From = from;
            myMessage.Subject = "Centric Nomination";
            // the body of the email is hard coded here but could be dynamically created using data
            // from the model- see the note at the end of this document
            myMessage.Body = "One of your colleges has nominated you! ";
            myMessage.Body += "Return to your Centric account to view this nomination!";
            try
            {
                myClient.Send(myMessage);
                TempData["mailError"] = "";
            }
            catch (Exception ex)
            {
                // this captures an Exception and allows you to display the message in the View
                TempData["mailError"] = ex.Message;
                return View("mailError");
            }// first, the customer found in the order is used to locate the customer record
            var profile = db.Profiles.Find(nominationPage.recognized);
            // then extract the email address from the customer record
            var nominateEmail = profile.email;
            // finally, add the email address to the “To” list
            myMessage.To.Add(nominateEmail);
            // note: it is possible to add more than one email address to the To list
            // it is also possible to add CC addresses

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
