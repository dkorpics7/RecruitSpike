using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RecruitSpike.Models
{
    public class MStatusController : Controller
    {
        private RecruitSpikeEntities db = new RecruitSpikeEntities();

        // GET: MStatus
        public ActionResult Index()
        {
            return View(db.MStatus.ToList());
        }

        // GET: MStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MStatu mStatu = db.MStatus.Find(id);
            if (mStatu == null)
            {
                return HttpNotFound();
            }
            return View(mStatu);
        }

        // GET: MStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MStatusID,Status")] MStatu mStatu)
        {
            if (ModelState.IsValid)
            {
                db.MStatus.Add(mStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mStatu);
        }

        // GET: MStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MStatu mStatu = db.MStatus.Find(id);
            if (mStatu == null)
            {
                return HttpNotFound();
            }
            return View(mStatu);
        }

        // POST: MStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MStatusID,Status")] MStatu mStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mStatu);
        }

        // GET: MStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MStatu mStatu = db.MStatus.Find(id);
            if (mStatu == null)
            {
                return HttpNotFound();
            }
            return View(mStatu);
        }

        // POST: MStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MStatu mStatu = db.MStatus.Find(id);
            db.MStatus.Remove(mStatu);
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
