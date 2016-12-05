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
    public class InsiderProfileModulesController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: InsiderProfileModules
        public ActionResult Index()
        {
            var insiderProfileModules = db.InsiderProfileModules.Include(i => i.InsiderHeaderPhoto).Include(i => i.InsiderPhoto).Include(i => i.InsiderProfile).Include(i => i.InsiderSkill);
            return View(insiderProfileModules.ToList());
        }

        // GET: InsiderProfileModules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderProfileModule insiderProfileModule = db.InsiderProfileModules.Find(id);
            if (insiderProfileModule == null)
            {
                return HttpNotFound();
            }
            return View(insiderProfileModule);
        }

        // GET: InsiderProfileModules/Create
        public ActionResult Create()
        {
            ViewBag.InsiderHeaderPhotoID = new SelectList(db.InsiderHeaderPhotoes, "InsiderHeaderPhotoID", "HeaderFileName");
            ViewBag.InsiderPhotoID = new SelectList(db.InsiderPhotoes, "InsiderPhotoID", "PhotoFileName");
            ViewBag.InsiderProfileID = new SelectList(db.InsiderProfiles, "InsiderProfileID", "InsiderProfileID");
            ViewBag.InsiderSkillID = new SelectList(db.InsiderSkills, "InsiderSkillID", "InsiderSkillID");
            return View();
        }

        // POST: InsiderProfileModules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsiderProfileModuleID,InsiderProfileID,InsiderPhotoID,InsiderHeaderPhotoID,InsiderSkillID")] InsiderProfileModule insiderProfileModule)
        {
            if (ModelState.IsValid)
            {
                db.InsiderProfileModules.Add(insiderProfileModule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsiderHeaderPhotoID = new SelectList(db.InsiderHeaderPhotoes, "InsiderHeaderPhotoID", "HeaderFileName", insiderProfileModule.InsiderHeaderPhotoID);
            ViewBag.InsiderPhotoID = new SelectList(db.InsiderPhotoes, "InsiderPhotoID", "PhotoFileName", insiderProfileModule.InsiderPhotoID);
            ViewBag.InsiderProfileID = new SelectList(db.InsiderProfiles, "InsiderProfileID", "InsiderProfileID", insiderProfileModule.InsiderProfileID);
            ViewBag.InsiderSkillID = new SelectList(db.InsiderSkills, "InsiderSkillID", "InsiderSkillID", insiderProfileModule.InsiderSkillID);
            return View(insiderProfileModule);
        }

        // GET: InsiderProfileModules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderProfileModule insiderProfileModule = db.InsiderProfileModules.Find(id);
            if (insiderProfileModule == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsiderHeaderPhotoID = new SelectList(db.InsiderHeaderPhotoes, "InsiderHeaderPhotoID", "HeaderFileName", insiderProfileModule.InsiderHeaderPhotoID);
            ViewBag.InsiderPhotoID = new SelectList(db.InsiderPhotoes, "InsiderPhotoID", "PhotoFileName", insiderProfileModule.InsiderPhotoID);
            ViewBag.InsiderProfileID = new SelectList(db.InsiderProfiles, "InsiderProfileID", "InsiderProfileID", insiderProfileModule.InsiderProfileID);
            ViewBag.InsiderSkillID = new SelectList(db.InsiderSkills, "InsiderSkillID", "InsiderSkillID", insiderProfileModule.InsiderSkillID);
            return View(insiderProfileModule);
        }

        // POST: InsiderProfileModules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsiderProfileModuleID,InsiderProfileID,InsiderPhotoID,InsiderHeaderPhotoID,InsiderSkillID")] InsiderProfileModule insiderProfileModule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insiderProfileModule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsiderHeaderPhotoID = new SelectList(db.InsiderHeaderPhotoes, "InsiderHeaderPhotoID", "HeaderFileName", insiderProfileModule.InsiderHeaderPhotoID);
            ViewBag.InsiderPhotoID = new SelectList(db.InsiderPhotoes, "InsiderPhotoID", "PhotoFileName", insiderProfileModule.InsiderPhotoID);
            ViewBag.InsiderProfileID = new SelectList(db.InsiderProfiles, "InsiderProfileID", "InsiderProfileID", insiderProfileModule.InsiderProfileID);
            ViewBag.InsiderSkillID = new SelectList(db.InsiderSkills, "InsiderSkillID", "InsiderSkillID", insiderProfileModule.InsiderSkillID);
            return View(insiderProfileModule);
        }

        // GET: InsiderProfileModules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderProfileModule insiderProfileModule = db.InsiderProfileModules.Find(id);
            if (insiderProfileModule == null)
            {
                return HttpNotFound();
            }
            return View(insiderProfileModule);
        }

        // POST: InsiderProfileModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsiderProfileModule insiderProfileModule = db.InsiderProfileModules.Find(id);
            db.InsiderProfileModules.Remove(insiderProfileModule);
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
