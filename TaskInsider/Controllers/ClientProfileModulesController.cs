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
    public class ClientProfileModulesController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: ClientProfileModules
        public ActionResult Index()
        {
            var clientProfileModules = db.ClientProfileModules.Include(c => c.ClientHeaderPhoto).Include(c => c.ClientPhoto).Include(c => c.ClientProfile);
            return View(clientProfileModules.ToList());
        }

        // GET: ClientProfileModules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientProfileModule clientProfileModule = db.ClientProfileModules.Find(id);
            if (clientProfileModule == null)
            {
                return HttpNotFound();
            }
            return View(clientProfileModule);
        }

        // GET: ClientProfileModules/Create
        public ActionResult Create()
        {
            ViewBag.ClientHeaderPhotoID = new SelectList(db.ClientHeaderPhotoes, "ClientHeaderPhotoID", "HeaderFileName");
            ViewBag.ClientPhotoID = new SelectList(db.ClientPhotoes, "ClientPhotoID", "PhotoFileName");
            ViewBag.ClientProfileID = new SelectList(db.ClientProfiles, "ClientProfileID", "ClientProfileID");
            return View();
        }

        // POST: ClientProfileModules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientProfileModuleID,ClientProfileID,ClientPhotoID,ClientHeaderPhotoID")] ClientProfileModule clientProfileModule)
        {
            if (ModelState.IsValid)
            {
                db.ClientProfileModules.Add(clientProfileModule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientHeaderPhotoID = new SelectList(db.ClientHeaderPhotoes, "ClientHeaderPhotoID", "HeaderFileName", clientProfileModule.ClientHeaderPhotoID);
            ViewBag.ClientPhotoID = new SelectList(db.ClientPhotoes, "ClientPhotoID", "PhotoFileName", clientProfileModule.ClientPhotoID);
            ViewBag.ClientProfileID = new SelectList(db.ClientProfiles, "ClientProfileID", "ClientProfileID", clientProfileModule.ClientProfileID);
            return View(clientProfileModule);
        }

        // GET: ClientProfileModules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientProfileModule clientProfileModule = db.ClientProfileModules.Find(id);
            if (clientProfileModule == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientHeaderPhotoID = new SelectList(db.ClientHeaderPhotoes, "ClientHeaderPhotoID", "HeaderFileName", clientProfileModule.ClientHeaderPhotoID);
            ViewBag.ClientPhotoID = new SelectList(db.ClientPhotoes, "ClientPhotoID", "PhotoFileName", clientProfileModule.ClientPhotoID);
            ViewBag.ClientProfileID = new SelectList(db.ClientProfiles, "ClientProfileID", "ClientProfileID", clientProfileModule.ClientProfileID);
            return View(clientProfileModule);
        }

        // POST: ClientProfileModules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientProfileModuleID,ClientProfileID,ClientPhotoID,ClientHeaderPhotoID")] ClientProfileModule clientProfileModule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientProfileModule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientHeaderPhotoID = new SelectList(db.ClientHeaderPhotoes, "ClientHeaderPhotoID", "HeaderFileName", clientProfileModule.ClientHeaderPhotoID);
            ViewBag.ClientPhotoID = new SelectList(db.ClientPhotoes, "ClientPhotoID", "PhotoFileName", clientProfileModule.ClientPhotoID);
            ViewBag.ClientProfileID = new SelectList(db.ClientProfiles, "ClientProfileID", "ClientProfileID", clientProfileModule.ClientProfileID);
            return View(clientProfileModule);
        }

        // GET: ClientProfileModules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientProfileModule clientProfileModule = db.ClientProfileModules.Find(id);
            if (clientProfileModule == null)
            {
                return HttpNotFound();
            }
            return View(clientProfileModule);
        }

        // POST: ClientProfileModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientProfileModule clientProfileModule = db.ClientProfileModules.Find(id);
            db.ClientProfileModules.Remove(clientProfileModule);
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
