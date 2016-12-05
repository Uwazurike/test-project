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
    public class ServiceOrderItemsController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: ServiceOrderItems
        public ActionResult Index()
        {
            var serviceOrderItems = db.ServiceOrderItems.Include(s => s.ServiceRequest);
            return View(serviceOrderItems.ToList());
        }

        // GET: ServiceOrderItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceOrderItem serviceOrderItem = db.ServiceOrderItems.Find(id);
            if (serviceOrderItem == null)
            {
                return HttpNotFound();
            }
            return View(serviceOrderItem);
        }

        // GET: ServiceOrderItems/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.ServiceRequests, "ServiceRequestID", "ServiceRequestID");
            return View();
        }

        // POST: ServiceOrderItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceOrderItemsID,OrderID")] ServiceOrderItem serviceOrderItem)
        {
            if (ModelState.IsValid)
            {
                db.ServiceOrderItems.Add(serviceOrderItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.ServiceRequests, "ServiceRequestID", "ServiceRequestID", serviceOrderItem.OrderID);
            return View(serviceOrderItem);
        }

        // GET: ServiceOrderItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceOrderItem serviceOrderItem = db.ServiceOrderItems.Find(id);
            if (serviceOrderItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.ServiceRequests, "ServiceRequestID", "ServiceRequestID", serviceOrderItem.OrderID);
            return View(serviceOrderItem);
        }

        // POST: ServiceOrderItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceOrderItemsID,OrderID")] ServiceOrderItem serviceOrderItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceOrderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.ServiceRequests, "ServiceRequestID", "ServiceRequestID", serviceOrderItem.OrderID);
            return View(serviceOrderItem);
        }

        // GET: ServiceOrderItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceOrderItem serviceOrderItem = db.ServiceOrderItems.Find(id);
            if (serviceOrderItem == null)
            {
                return HttpNotFound();
            }
            return View(serviceOrderItem);
        }

        // POST: ServiceOrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceOrderItem serviceOrderItem = db.ServiceOrderItems.Find(id);
            db.ServiceOrderItems.Remove(serviceOrderItem);
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
