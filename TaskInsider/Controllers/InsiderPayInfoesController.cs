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
    public class InsiderPayInfoesController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: InsiderPayInfoes
        public ActionResult Index()
        {
            var insiderPayInfoes = db.InsiderPayInfoes.Include(i => i.Insider);
            return View(insiderPayInfoes.ToList());
        }

        // GET: InsiderPayInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderPayInfo insiderPayInfo = db.InsiderPayInfoes.Find(id);
            if (insiderPayInfo == null)
            {
                return HttpNotFound();
            }
            return View(insiderPayInfo);
        }

        // GET: InsiderPayInfoes/Create
        public ActionResult Create()
        {
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName");
            return View();

        }


        // POST: InsiderPayInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsiderPayInfoID,InsiderID,BankName,RoutingNumber,AccountNumber")] InsiderPayInfo insiderPayInfo)
        {
            if (ModelState.IsValid)
            {
                db.InsiderPayInfoes.Add(insiderPayInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "InsiderFirstName", "InsiderLastName", insiderPayInfo.InsiderID);
            return View(insiderPayInfo);
        }

        // GET: InsiderPayInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderPayInfo insiderPayInfo = db.InsiderPayInfoes.Find(id);
            if (insiderPayInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "InsiderFirstName", "InsiderLastName", insiderPayInfo.InsiderID);
            return View(insiderPayInfo);
        }

        // POST: InsiderPayInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsiderPayInfoID,InsiderID,BankName,RoutingNumber,AccountNumber")] InsiderPayInfo insiderPayInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insiderPayInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "InsiderFirstName", "InsiderLastName", insiderPayInfo.InsiderID);
            return View(insiderPayInfo);
        }

        // GET: InsiderPayInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderPayInfo insiderPayInfo = db.InsiderPayInfoes.Find(id);
            if (insiderPayInfo == null)
            {
                return HttpNotFound();
            }
            return View(insiderPayInfo);
        }

        // POST: InsiderPayInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsiderPayInfo insiderPayInfo = db.InsiderPayInfoes.Find(id);
            db.InsiderPayInfoes.Remove(insiderPayInfo);
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
