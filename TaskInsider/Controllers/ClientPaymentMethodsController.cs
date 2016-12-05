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
    public class ClientPaymentMethodsController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: ClientPaymentMethods
        public ActionResult Index()
        {
            var clientPaymentMethods = db.ClientPaymentMethods.Include(c => c.Client).Include(c => c.PaymentMethod);
            return View(clientPaymentMethods.ToList());
        }

        // GET: ClientPaymentMethods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPaymentMethod clientPaymentMethod = db.ClientPaymentMethods.Find(id);
            if (clientPaymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(clientPaymentMethod);
        }

        // GET: ClientPaymentMethods/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName");
            ViewBag.PaymentMethodID = new SelectList(db.PaymentMethods, "PaymentMethodID", "PaymentMethod1");
            return View();
        }

        // POST: ClientPaymentMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientPaymentMethodID,ClientID,PaymentMethodID,CardNumber,ExpirationDate,CvC")] ClientPaymentMethod clientPaymentMethod)
        {
            if (ModelState.IsValid)
            {
                db.ClientPaymentMethods.Add(clientPaymentMethod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientPaymentMethod.ClientID);
            ViewBag.PaymentMethodID = new SelectList(db.PaymentMethods, "PaymentMethodID", "PaymentMethod1", clientPaymentMethod.PaymentMethodID);
            return View(clientPaymentMethod);
        }

        // GET: ClientPaymentMethods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPaymentMethod clientPaymentMethod = db.ClientPaymentMethods.Find(id);
            if (clientPaymentMethod == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientPaymentMethod.ClientID);
            ViewBag.PaymentMethodID = new SelectList(db.PaymentMethods, "PaymentMethodID", "PaymentMethod1", clientPaymentMethod.PaymentMethodID);
            return View(clientPaymentMethod);
        }

        // POST: ClientPaymentMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientPaymentMethodID,ClientID,PaymentMethodID,CardNumber,ExpirationDate,CvC")] ClientPaymentMethod clientPaymentMethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientPaymentMethod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientPaymentMethod.ClientID);
            ViewBag.PaymentMethodID = new SelectList(db.PaymentMethods, "PaymentMethodID", "PaymentMethod1", clientPaymentMethod.PaymentMethodID);
            return View(clientPaymentMethod);
        }

        // GET: ClientPaymentMethods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPaymentMethod clientPaymentMethod = db.ClientPaymentMethods.Find(id);
            if (clientPaymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(clientPaymentMethod);
        }

        // POST: ClientPaymentMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientPaymentMethod clientPaymentMethod = db.ClientPaymentMethods.Find(id);
            db.ClientPaymentMethods.Remove(clientPaymentMethod);
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
