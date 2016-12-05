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
    public class InsiderProfilesController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: InsiderProfiles
        public ActionResult Index()
        {
            var insiderProfiles = db.InsiderProfiles.Include(i => i.Insider);
            return View(insiderProfiles.ToList());
        }

        // GET: InsiderProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderProfile insiderProfile = db.InsiderProfiles.Find(id);
            if (insiderProfile == null)
            {
                return HttpNotFound();
            }
            return View(insiderProfile);
        }

        // GET: InsiderProfiles/Create
        public ActionResult Create()
        {
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName");
            return View();
        }

        // POST: InsiderProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsiderProfileID,InsiderID")] InsiderProfile insiderProfile)
        {
            if (ModelState.IsValid)
            {
                db.InsiderProfiles.Add(insiderProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", insiderProfile.InsiderID);
            return View(insiderProfile);
        }

        // GET: InsiderProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderProfile insiderProfile = db.InsiderProfiles.Find(id);
            if (insiderProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", insiderProfile.InsiderID);
            return View(insiderProfile);
        }

        // POST: InsiderProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsiderProfileID,InsiderID")] InsiderProfile insiderProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insiderProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", insiderProfile.InsiderID);
            return View(insiderProfile);
        }

        // GET: InsiderProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderProfile insiderProfile = db.InsiderProfiles.Find(id);
            if (insiderProfile == null)
            {
                return HttpNotFound();
            }
            return View(insiderProfile);
        }

        // POST: InsiderProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsiderProfile insiderProfile = db.InsiderProfiles.Find(id);
            db.InsiderProfiles.Remove(insiderProfile);
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
