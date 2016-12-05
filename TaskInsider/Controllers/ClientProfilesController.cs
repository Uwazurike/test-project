using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskInsider;

namespace TaskInsider.Controllers
{
    public class ClientProfilesController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: ClientProfiles
        public ActionResult Index()
        {
            var clientProfiles = db.ClientProfiles.Include(c => c.Client);
            return View(clientProfiles.ToList());
        }

        // GET: ClientProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientProfile clientProfile = db.ClientProfiles.Find(id);
            if (clientProfile == null)
            {
                return HttpNotFound();
            }
            return View(clientProfile);
        }

        // GET: ClientProfiles/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName");
            return View();
        }

        // POST: ClientProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientProfileID,ClientID")] ClientProfile clientProfile)
        {
            if (ModelState.IsValid)
            {
                db.ClientProfiles.Add(clientProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientProfile.ClientID);
            return View(clientProfile);
        }

        // GET: ClientProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientProfile clientProfile = db.ClientProfiles.Find(id);
            if (clientProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientProfile.ClientID);
            return View(clientProfile);
        }

        // POST: ClientProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientProfileID,ClientID")] ClientProfile clientProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientProfile.ClientID);
            return View(clientProfile);
        }

        // GET: ClientProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientProfile clientProfile = db.ClientProfiles.Find(id);
            if (clientProfile == null)
            {
                return HttpNotFound();
            }
            return View(clientProfile);
        }

        // POST: ClientProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientProfile clientProfile = db.ClientProfiles.Find(id);
            db.ClientProfiles.Remove(clientProfile);
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
