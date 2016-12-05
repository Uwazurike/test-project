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
    public class ClientAddressesController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: ClientAddresses
        public ActionResult Index()
        {
            var clientAddresses = db.ClientAddresses.Include(c => c.Address).Include(c => c.AddressType).Include(c => c.Client);
            return View(clientAddresses.ToList());
        }

        // GET: ClientAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientAddress clientAddress = db.ClientAddresses.Find(id);
            if (clientAddress == null)
            {
                return HttpNotFound();
            }
            return View(clientAddress);
        }

        // GET: ClientAddresses/Create
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", "City", "State", "ZipCode");
            ViewBag.AddressTypeID = new SelectList(db.AddressTypes, "AddressTypeID", "AddressType1");
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientFirstName", "ClientLastName");
            return View();
        }

        // POST: ClientAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientAddressID,ClientID,AddressID,AddressTypeID")] ClientAddress clientAddress)
        {
            if (ModelState.IsValid)
            {
                db.ClientAddresses.Add(clientAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", clientAddress.AddressID);
            ViewBag.AddressTypeID = new SelectList(db.AddressTypes, "AddressTypeID", "AddressType1", clientAddress.AddressTypeID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientAddress.ClientID);
            return View(clientAddress);
        }

        // GET: ClientAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientAddress clientAddress = db.ClientAddresses.Find(id);
            if (clientAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", clientAddress.AddressID);
            ViewBag.AddressTypeID = new SelectList(db.AddressTypes, "AddressTypeID", "AddressType1", clientAddress.AddressTypeID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientAddress.ClientID);
            return View(clientAddress);
        }

        // POST: ClientAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientAddressID,ClientID,AddressID,AddressTypeID")] ClientAddress clientAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", clientAddress.AddressID);
            ViewBag.AddressTypeID = new SelectList(db.AddressTypes, "AddressTypeID", "AddressType1", clientAddress.AddressTypeID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientAddress.ClientID);
            return View(clientAddress);
        }

        // GET: ClientAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientAddress clientAddress = db.ClientAddresses.Find(id);
            if (clientAddress == null)
            {
                return HttpNotFound();
            }
            return View(clientAddress);
        }

        // POST: ClientAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientAddress clientAddress = db.ClientAddresses.Find(id);
            db.ClientAddresses.Remove(clientAddress);
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
