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
    public class ServiceRequestsController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: ServiceRequests
        public ActionResult Index()
        {
            var serviceRequests = db.ServiceRequests.Include(s => s.Client).Include(s => s.ClientPaymentStatu).Include(s => s.Insider).Include(s => s.InsiderPayStatu).Include(s => s.RequestStatu).Include(s => s.Service).Include(s => s.ServiceRequest2);
            return View(serviceRequests.ToList());
        }

        // GET: ServiceRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            return View(serviceRequest);
        }

        // GET: ServiceRequests/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName");
            ViewBag.ClientPaymentStatusID = new SelectList(db.ClientPaymentStatus, "ClientPaymentStatusID", "ClientPaymentStatus");
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName");
            ViewBag.InsiderPayStatusID = new SelectList(db.InsiderPayStatus, "InsiderPayStatusID", "InsiderPayStatus");
            ViewBag.RequestStatusID = new SelectList(db.RequestStatus, "RequestStatusID", "RequestStatus");
            ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceName");
            ViewBag.RelatedServiceRequestID = new SelectList(db.ServiceRequests, "ServiceRequestID", "ServiceRequestID");
            return View();
        }

        // POST: ServiceRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceRequestID,ClientID,RelatedServiceRequestID,ServiceID,InsiderID,HoursOverMinimum,TotalHoursWorked,TotalAmount,FinalEarnings,ClientPaymentStatusID,RequestStatusID,ServiceCompletionDate,InsiderPayStatusID,InsiderPayDate")] ServiceRequest serviceRequest)
        {
            if (ModelState.IsValid)
            {
                db.ServiceRequests.Add(serviceRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", serviceRequest.ClientID);
            ViewBag.ClientPaymentStatusID = new SelectList(db.ClientPaymentStatus, "ClientPaymentStatusID", "ClientPaymentStatus", serviceRequest.ClientPaymentStatusID);
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", serviceRequest.InsiderID);
            ViewBag.InsiderPayStatusID = new SelectList(db.InsiderPayStatus, "InsiderPayStatusID", "InsiderPayStatus", serviceRequest.InsiderPayStatusID);
            ViewBag.RequestStatusID = new SelectList(db.RequestStatus, "RequestStatusID", "RequestStatus", serviceRequest.RequestStatusID);
            ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceName", serviceRequest.ServiceID);
            ViewBag.RelatedServiceRequestID = new SelectList(db.ServiceRequests, "ServiceRequestID", "ServiceRequestID", serviceRequest.RelatedServiceRequestID);
            return View(serviceRequest);
        }

        // GET: ServiceRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", serviceRequest.ClientID);
            ViewBag.ClientPaymentStatusID = new SelectList(db.ClientPaymentStatus, "ClientPaymentStatusID", "ClientPaymentStatus", serviceRequest.ClientPaymentStatusID);
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", serviceRequest.InsiderID);
            ViewBag.InsiderPayStatusID = new SelectList(db.InsiderPayStatus, "InsiderPayStatusID", "InsiderPayStatus", serviceRequest.InsiderPayStatusID);
            ViewBag.RequestStatusID = new SelectList(db.RequestStatus, "RequestStatusID", "RequestStatus", serviceRequest.RequestStatusID);
            ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceName", serviceRequest.ServiceID);
            ViewBag.RelatedServiceRequestID = new SelectList(db.ServiceRequests, "ServiceRequestID", "ServiceRequestID", serviceRequest.RelatedServiceRequestID);
            return View(serviceRequest);
        }

        // POST: ServiceRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceRequestID,ClientID,RelatedServiceRequestID,ServiceID,InsiderID,HoursOverMinimum,TotalHoursWorked,TotalAmount,FinalEarnings,ClientPaymentStatusID,RequestStatusID,ServiceCompletionDate,InsiderPayStatusID,InsiderPayDate")] ServiceRequest serviceRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", serviceRequest.ClientID);
            ViewBag.ClientPaymentStatusID = new SelectList(db.ClientPaymentStatus, "ClientPaymentStatusID", "ClientPaymentStatus", serviceRequest.ClientPaymentStatusID);
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", serviceRequest.InsiderID);
            ViewBag.InsiderPayStatusID = new SelectList(db.InsiderPayStatus, "InsiderPayStatusID", "InsiderPayStatus", serviceRequest.InsiderPayStatusID);
            ViewBag.RequestStatusID = new SelectList(db.RequestStatus, "RequestStatusID", "RequestStatus", serviceRequest.RequestStatusID);
            ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceName", serviceRequest.ServiceID);
            ViewBag.RelatedServiceRequestID = new SelectList(db.ServiceRequests, "ServiceRequestID", "ServiceRequestID", serviceRequest.RelatedServiceRequestID);
            return View(serviceRequest);
        }

        // GET: ServiceRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            return View(serviceRequest);
        }

        // POST: ServiceRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            db.ServiceRequests.Remove(serviceRequest);
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
