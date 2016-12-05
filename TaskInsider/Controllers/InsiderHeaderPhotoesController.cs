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
    public class InsiderHeaderPhotoesController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: InsiderHeaderPhotoes
        public ActionResult Index()
        {
            var insiderHeaderPhotoes = db.InsiderHeaderPhotoes.Include(i => i.Insider);
            return View(insiderHeaderPhotoes.ToList());
        }

        // GET: InsiderHeaderPhotoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderHeaderPhoto insiderHeaderPhoto = db.InsiderHeaderPhotoes.Find(id);
            if (insiderHeaderPhoto == null)
            {
                return HttpNotFound();
            }
            return View(insiderHeaderPhoto);
        }

        // GET: InsiderHeaderPhotoes/Create
        public ActionResult Create()
        {
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName");
            return View();
        }

        // POST: InsiderHeaderPhotoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsiderHeaderPhotoID,InsiderID,HeaderFileName")] InsiderHeaderPhoto insiderHeaderPhoto)
        {
            if (ModelState.IsValid)
            {
                db.InsiderHeaderPhotoes.Add(insiderHeaderPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", insiderHeaderPhoto.InsiderID);
            return View(insiderHeaderPhoto);
        }

        // GET: InsiderHeaderPhotoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderHeaderPhoto insiderHeaderPhoto = db.InsiderHeaderPhotoes.Find(id);
            if (insiderHeaderPhoto == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", insiderHeaderPhoto.InsiderID);
            return View(insiderHeaderPhoto);
        }

        // POST: InsiderHeaderPhotoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsiderHeaderPhotoID,InsiderID,HeaderFileName")] InsiderHeaderPhoto insiderHeaderPhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insiderHeaderPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", insiderHeaderPhoto.InsiderID);
            return View(insiderHeaderPhoto);
        }

        // GET: InsiderHeaderPhotoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderHeaderPhoto insiderHeaderPhoto = db.InsiderHeaderPhotoes.Find(id);
            if (insiderHeaderPhoto == null)
            {
                return HttpNotFound();
            }
            return View(insiderHeaderPhoto);
        }

        // POST: InsiderHeaderPhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsiderHeaderPhoto insiderHeaderPhoto = db.InsiderHeaderPhotoes.Find(id);
            db.InsiderHeaderPhotoes.Remove(insiderHeaderPhoto);
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
