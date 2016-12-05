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
    public class InsiderPayStatusController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: InsiderPayStatus
        public ActionResult Index()
        {
            return View(db.InsiderPayStatus.ToList());
        }

        // GET: InsiderPayStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderPayStatu insiderPayStatu = db.InsiderPayStatus.Find(id);
            if (insiderPayStatu == null)
            {
                return HttpNotFound();
            }
            return View(insiderPayStatu);
        }

        // GET: InsiderPayStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsiderPayStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsiderPayStatusID,InsiderPayStatus")] InsiderPayStatu insiderPayStatu)
        {
            if (ModelState.IsValid)
            {
                db.InsiderPayStatus.Add(insiderPayStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insiderPayStatu);
        }

        // GET: InsiderPayStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderPayStatu insiderPayStatu = db.InsiderPayStatus.Find(id);
            if (insiderPayStatu == null)
            {
                return HttpNotFound();
            }
            return View(insiderPayStatu);
        }

        // POST: InsiderPayStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsiderPayStatusID,InsiderPayStatus")] InsiderPayStatu insiderPayStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insiderPayStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insiderPayStatu);
        }

        // GET: InsiderPayStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderPayStatu insiderPayStatu = db.InsiderPayStatus.Find(id);
            if (insiderPayStatu == null)
            {
                return HttpNotFound();
            }
            return View(insiderPayStatu);
        }

        // POST: InsiderPayStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsiderPayStatu insiderPayStatu = db.InsiderPayStatus.Find(id);
            db.InsiderPayStatus.Remove(insiderPayStatu);
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
