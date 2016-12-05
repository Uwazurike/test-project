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
    public class InsiderPhotoesController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: InsiderPhotoes
        public ActionResult Index()
        {
            var insiderPhotoes = db.InsiderPhotoes.Include(i => i.Insider);
            return View(insiderPhotoes.ToList());
        }

        // GET: InsiderPhotoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderPhoto insiderPhoto = db.InsiderPhotoes.Find(id);
            if (insiderPhoto == null)
            {
                return HttpNotFound();
            }
            return View(insiderPhoto);
        }

        // GET: InsiderPhotoes/Create
        public ActionResult Create()
        {
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName");
            return View();
        }

        // POST: InsiderPhotoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsiderPhotoID,InsiderID,PhotoFileName")] InsiderPhoto insiderPhoto)
        {
            if (ModelState.IsValid)
            {
                db.InsiderPhotoes.Add(insiderPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", insiderPhoto.InsiderID);
            return View(insiderPhoto);
        }

        // GET: InsiderPhotoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderPhoto insiderPhoto = db.InsiderPhotoes.Find(id);
            if (insiderPhoto == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", insiderPhoto.InsiderID);
            return View(insiderPhoto);
        }

        // POST: InsiderPhotoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsiderPhotoID,InsiderID,PhotoFileName")] InsiderPhoto insiderPhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insiderPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", insiderPhoto.InsiderID);
            return View(insiderPhoto);
        }

        // GET: InsiderPhotoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderPhoto insiderPhoto = db.InsiderPhotoes.Find(id);
            if (insiderPhoto == null)
            {
                return HttpNotFound();
            }
            return View(insiderPhoto);
        }

        // POST: InsiderPhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsiderPhoto insiderPhoto = db.InsiderPhotoes.Find(id);
            db.InsiderPhotoes.Remove(insiderPhoto);
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
