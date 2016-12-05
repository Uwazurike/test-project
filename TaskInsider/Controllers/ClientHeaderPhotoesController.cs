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
    public class ClientHeaderPhotoesController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: ClientHeaderPhotoes
        public ActionResult Index()
        {
            var clientHeaderPhotoes = db.ClientHeaderPhotoes.Include(c => c.Client);
            return View(clientHeaderPhotoes.ToList());
        }

        // GET: ClientHeaderPhotoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientHeaderPhoto clientHeaderPhoto = db.ClientHeaderPhotoes.Find(id);
            if (clientHeaderPhoto == null)
            {
                return HttpNotFound();
            }
            return View(clientHeaderPhoto);
        }

        // GET: ClientHeaderPhotoes/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName");
            return View();
        }

        // POST: ClientHeaderPhotoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientHeaderPhotoID,ClientID,HeaderFileName")] ClientHeaderPhoto clientHeaderPhoto)
        {
            if (ModelState.IsValid)
            {
                db.ClientHeaderPhotoes.Add(clientHeaderPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientHeaderPhoto.ClientID);
            return View(clientHeaderPhoto);
        }

        // GET: ClientHeaderPhotoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientHeaderPhoto clientHeaderPhoto = db.ClientHeaderPhotoes.Find(id);
            if (clientHeaderPhoto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientHeaderPhoto.ClientID);
            return View(clientHeaderPhoto);
        }

        // POST: ClientHeaderPhotoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientHeaderPhotoID,ClientID,HeaderFileName")] ClientHeaderPhoto clientHeaderPhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientHeaderPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientHeaderPhoto.ClientID);
            return View(clientHeaderPhoto);
        }

        // GET: ClientHeaderPhotoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientHeaderPhoto clientHeaderPhoto = db.ClientHeaderPhotoes.Find(id);
            if (clientHeaderPhoto == null)
            {
                return HttpNotFound();
            }
            return View(clientHeaderPhoto);
        }

        // POST: ClientHeaderPhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientHeaderPhoto clientHeaderPhoto = db.ClientHeaderPhotoes.Find(id);
            db.ClientHeaderPhotoes.Remove(clientHeaderPhoto);
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
