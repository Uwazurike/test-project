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
    public class ClientPaymentStatusController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: ClientPaymentStatus
        public ActionResult Index()
        {
            return View(db.ClientPaymentStatus.ToList());
        }

        // GET: ClientPaymentStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPaymentStatu clientPaymentStatu = db.ClientPaymentStatus.Find(id);
            if (clientPaymentStatu == null)
            {
                return HttpNotFound();
            }
            return View(clientPaymentStatu);
        }

        // GET: ClientPaymentStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientPaymentStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientPaymentStatusID,ClientPaymentStatus")] ClientPaymentStatu clientPaymentStatu)
        {
            if (ModelState.IsValid)
            {
                db.ClientPaymentStatus.Add(clientPaymentStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientPaymentStatu);
        }

        // GET: ClientPaymentStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPaymentStatu clientPaymentStatu = db.ClientPaymentStatus.Find(id);
            if (clientPaymentStatu == null)
            {
                return HttpNotFound();
            }
            return View(clientPaymentStatu);
        }

        // POST: ClientPaymentStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientPaymentStatusID,ClientPaymentStatus")] ClientPaymentStatu clientPaymentStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientPaymentStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientPaymentStatu);
        }

        // GET: ClientPaymentStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPaymentStatu clientPaymentStatu = db.ClientPaymentStatus.Find(id);
            if (clientPaymentStatu == null)
            {
                return HttpNotFound();
            }
            return View(clientPaymentStatu);
        }

        // POST: ClientPaymentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientPaymentStatu clientPaymentStatu = db.ClientPaymentStatus.Find(id);
            db.ClientPaymentStatus.Remove(clientPaymentStatu);
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
