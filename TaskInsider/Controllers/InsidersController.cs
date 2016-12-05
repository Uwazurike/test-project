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
    public class InsidersController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: Insiders
        public ActionResult Index()
        {
            var insiders = db.Insiders.Include(i => i.Address);
            return View(insiders.ToList());
        }

        // GET: Insiders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insider insider = db.Insiders.Find(id);
            if (insider == null)
            {
                return HttpNotFound();
            }
            return View(insider);
        }

        // GET: Insiders/Create
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress","City","State","ZipCode");
            return View();
        }

        // POST: Insiders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsiderID,UserName,InsiderFirstName,InsiderLastName,AddressID,InsiderEmailAddress,InsiderPhoneNumber")] Insider insider)
        {
            if (ModelState.IsValid)
            {
                db.Insiders.Add(insider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", insider.AddressID);
            return View(insider);
        }

        // GET: Insiders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insider insider = db.Insiders.Find(id);
            if (insider == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", insider.AddressID);
            return View(insider);
        }

        // POST: Insiders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsiderID,UserName,InsiderFirstName,InsiderLastName,AddressID,InsiderEmailAddress,InsiderPhoneNumber")] Insider insider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", insider.AddressID);
            return View(insider);
        }

        // GET: Insiders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insider insider = db.Insiders.Find(id);
            if (insider == null)
            {
                return HttpNotFound();
            }
            return View(insider);
        }

        // POST: Insiders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insider insider = db.Insiders.Find(id);
            db.Insiders.Remove(insider);
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
