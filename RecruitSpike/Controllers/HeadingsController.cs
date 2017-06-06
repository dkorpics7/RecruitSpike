using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecruitSpike.Models;

namespace RecruitSpike.Controllers
{
    public class HeadingsController : Controller
    {
        private RecruitSpikeEntities db = new RecruitSpikeEntities();

        // GET: Headings
        public ActionResult Index()
        {
            var headings = db.Headings.Include(h => h.Mainstep);
            return View(headings.ToList());
        }

        // GET: Headings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heading heading = db.Headings.Find(id);
            if (heading == null)
            {
                return HttpNotFound();
            }
            return View(heading);
        }

        // GET: Headings/Create
        public ActionResult Create()
        {
            ViewBag.MainstepID = new SelectList(db.Mainsteps, "MainstepID", "Name");
            return View();
        }

        // POST: Headings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HeadingID,Number,Name,DueDate,IsDone,Notes,Effort,MainstepID")] Heading heading)
        {
            if (ModelState.IsValid)
            {
                db.Headings.Add(heading);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MainstepID = new SelectList(db.Mainsteps, "MainstepID", "Name", heading.MainstepID);
            return View(heading);
        }

        // GET: Headings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heading heading = db.Headings.Find(id);
            if (heading == null)
            {
                return HttpNotFound();
            }
            ViewBag.MainstepID = new SelectList(db.Mainsteps, "MainstepID", "Name", heading.MainstepID);
            return View(heading);
        }

        // POST: Headings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HeadingID,Number,Name,DueDate,IsDone,Notes,Effort,MainstepID")] Heading heading)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heading).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MainstepID = new SelectList(db.Mainsteps, "MainstepID", "Name", heading.MainstepID);
            return View(heading);
        }

        // GET: Headings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heading heading = db.Headings.Find(id);
            if (heading == null)
            {
                return HttpNotFound();
            }
            return View(heading);
        }

        // POST: Headings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Heading heading = db.Headings.Find(id);
            db.Headings.Remove(heading);
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
