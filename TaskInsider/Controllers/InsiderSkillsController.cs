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
    public class InsiderSkillsController : Controller
    {
        private TaskInsiderEntities db = new TaskInsiderEntities();

        // GET: InsiderSkills
        public ActionResult Index()
        {
            var insiderSkills = db.InsiderSkills.Include(i => i.Insider).Include(i => i.Skill).Include(i => i.SkillLevel);
            return View(insiderSkills.ToList());
        }

        // GET: InsiderSkills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderSkill insiderSkill = db.InsiderSkills.Find(id);
            if (insiderSkill == null)
            {
                return HttpNotFound();
            }
            return View(insiderSkill);
        }

        // GET: InsiderSkills/Create
        public ActionResult Create()
        {
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName");
            ViewBag.SkillID = new SelectList(db.Skills, "SkillID", "SkillName");
            ViewBag.SkillLevelID = new SelectList(db.SkillLevels, "SkillLevelID", "SkillLevelName");
            return View();
        }

        // POST: InsiderSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsiderSkillID,InsiderID,SkillID,SkillLevelID")] InsiderSkill insiderSkill)
        {
            if (ModelState.IsValid)
            {
                db.InsiderSkills.Add(insiderSkill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", insiderSkill.InsiderID);
            ViewBag.SkillID = new SelectList(db.Skills, "SkillID", "SkillName", insiderSkill.SkillID);
            ViewBag.SkillLevelID = new SelectList(db.SkillLevels, "SkillLevelID", "SkillLevelName", insiderSkill.SkillLevelID);
            return View(insiderSkill);
        }

        // GET: InsiderSkills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderSkill insiderSkill = db.InsiderSkills.Find(id);
            if (insiderSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", insiderSkill.InsiderID);
            ViewBag.SkillID = new SelectList(db.Skills, "SkillID", "SkillName", insiderSkill.SkillID);
            ViewBag.SkillLevelID = new SelectList(db.SkillLevels, "SkillLevelID", "SkillLevelName", insiderSkill.SkillLevelID);
            return View(insiderSkill);
        }

        // POST: InsiderSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsiderSkillID,InsiderID,SkillID,SkillLevelID")] InsiderSkill insiderSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insiderSkill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsiderID = new SelectList(db.Insiders, "InsiderID", "UserName", insiderSkill.InsiderID);
            ViewBag.SkillID = new SelectList(db.Skills, "SkillID", "SkillName", insiderSkill.SkillID);
            ViewBag.SkillLevelID = new SelectList(db.SkillLevels, "SkillLevelID", "SkillLevelName", insiderSkill.SkillLevelID);
            return View(insiderSkill);
        }

        // GET: InsiderSkills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsiderSkill insiderSkill = db.InsiderSkills.Find(id);
            if (insiderSkill == null)
            {
                return HttpNotFound();
            }
            return View(insiderSkill);
        }

        // POST: InsiderSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsiderSkill insiderSkill = db.InsiderSkills.Find(id);
            db.InsiderSkills.Remove(insiderSkill);
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
