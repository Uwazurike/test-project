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
    public class ClientPhotoesController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: ClientPhotoes
        public ActionResult Index()
        {
            var clientPhotoes = db.ClientPhotoes.Include(c => c.Client);
            return View(clientPhotoes.ToList());
        }

        // GET: ClientPhotoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPhoto clientPhoto = db.ClientPhotoes.Find(id);
            if (clientPhoto == null)
            {
                return HttpNotFound();
            }
            return View(clientPhoto);
        }

        // GET: ClientPhotoes/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName");
            return View();
        }

        // POST: ClientPhotoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientPhotoID,ClientID,PhotoFileName")] ClientPhoto clientPhoto)
        {
            if (ModelState.IsValid)
            {
                db.ClientPhotoes.Add(clientPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientPhoto.ClientID);
            return View(clientPhoto);
        }

        // GET: ClientPhotoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPhoto clientPhoto = db.ClientPhotoes.Find(id);
            if (clientPhoto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientPhoto.ClientID);
            return View(clientPhoto);
        }

        // POST: ClientPhotoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientPhotoID,ClientID,PhotoFileName")] ClientPhoto clientPhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "UserName", clientPhoto.ClientID);
            return View(clientPhoto);
        }

        // GET: ClientPhotoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPhoto clientPhoto = db.ClientPhotoes.Find(id);
            if (clientPhoto == null)
            {
                return HttpNotFound();
            }
            return View(clientPhoto);
        }

        // POST: ClientPhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientPhoto clientPhoto = db.ClientPhotoes.Find(id);
            db.ClientPhotoes.Remove(clientPhoto);
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
