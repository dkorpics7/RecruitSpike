using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace RecruitSpike.Models
{
    public class ProfilesController : Controller
    {
        private RecruitSpikeEntities db = new RecruitSpikeEntities();

        // GET: Profiles
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            //can do this.... or....
            //return RedirectToAction("Details",currentUserId);

            //    var profiles = db.Profiles.Include(p => p.AspNetUser).Include(p => p.Education).Include(p => p.MStatu).Include(p => p.PriorService).Include(p => p.Roadmap).Include(p => p.MStatu);
            //    return View(profiles.ToList());
            //   ... this ...
            var profiles = (from p in db.Profiles
                            where p.Id==currentUserId
                            select p);
            return View(profiles.ToList());
        }

        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            //check to see if user already has a profile
            var profiles = db.Profiles.Include(p => p.AspNetUser).Include(p => p.Education).Include(p => p.MStatu).Include(p => p.PriorService).Include(p => p.Roadmap).Include(p => p.MStatu);
            foreach (var p in profiles)
            {
                if(p.Id==User.Identity.GetUserId())
                {
                    // check progress on steps 1, 2, and 3 by checking IsDone.  Go to appropriate page.
                    // may have to write a method that passes special info to view so that view can
                    // go to correct location on page (e.g., #Mainstep2)      
                    //          if() return RedirectToAction("Details", currentUserId);
                    //for now, just send them to Index so that can scroll to mainstep 1
                    return RedirectToAction("Index");
                }
            }
            //create profile for new user
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.EducationID = new SelectList(db.Educations, "EducationID", "EdLevel");
            ViewBag.PriorServiceID = new SelectList(db.PriorServices, "PriorServiceID", "Service1");
            ViewBag.RoadmapID = new SelectList(db.Roadmaps, "RoadmapID", "RoadmapName");
            ViewBag.MStatusID = new SelectList(db.MStatus, "MStatusID", "Status");
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfileID,FName,LName,DateOfBirth,Height,Weight,Dependents,Title,Branch,AsvabScore,PracticeScore,EducationID,MaritalStatusID,PriorServiceID,RoadmapID,Id,MStatusID")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                //set Id so user doesn't have to select it
                profile.Id = User.Identity.GetUserId();
                db.Profiles.Add(profile);
                db.SaveChanges();
                //return RedirectToAction("Details", User.Identity.GetUserId());
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", profile.Id);
            ViewBag.EducationID = new SelectList(db.Educations, "EducationID", "EdLevel", profile.EducationID);
            ViewBag.PriorServiceID = new SelectList(db.PriorServices, "PriorServiceID", "Service1", profile.PriorServiceID);
            ViewBag.RoadmapID = new SelectList(db.Roadmaps, "RoadmapID", "RoadmapName", profile.RoadmapID);
            ViewBag.MStatusID = new SelectList(db.MStatus, "MStatusID", "Status", profile.MStatusID);
            return View(profile);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", profile.Id);
            ViewBag.EducationID = new SelectList(db.Educations, "EducationID", "EdLevel", profile.EducationID);
            ViewBag.PriorServiceID = new SelectList(db.PriorServices, "PriorServiceID", "Service1", profile.PriorServiceID);
            ViewBag.RoadmapID = new SelectList(db.Roadmaps, "RoadmapID", "RoadmapName", profile.RoadmapID);
            ViewBag.MStatusID = new SelectList(db.MStatus, "MStatusID", "Status", profile.MStatusID);
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfileID,FName,LName,DateOfBirth,Height,Weight,Dependents,Title,Branch,AsvabScore,PracticeScore,EducationID,PriorServiceID,RoadmapID,Id,MStatusID")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                //set user id so user doesn't have to specify it 
                profile.Id = User.Identity.GetUserId();
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                RedirectToAction("Index");
                //return RedirectToAction("Details", User.Identity.GetUserId());
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", profile.Id);
            ViewBag.EducationID = new SelectList(db.Educations, "EducationID", "EdLevel", profile.EducationID);
            ViewBag.PriorServiceID = new SelectList(db.PriorServices, "PriorServiceID", "Service1", profile.PriorServiceID);
            ViewBag.RoadmapID = new SelectList(db.Roadmaps, "RoadmapID", "RoadmapName", profile.RoadmapID);
            ViewBag.MStatusID = new SelectList(db.MStatus, "MStatusID", "Status", profile.MStatusID);
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
            db.SaveChanges();
            //return RedirectToAction("Details", id);
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
