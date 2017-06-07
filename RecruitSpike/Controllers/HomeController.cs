using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Microsoft.AspNet.Identity;
//using RecruitSpike.Models;

namespace RecruitSpike.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        //private RecruitSpikeEntities db = new RecruitSpikeEntities();

        public ActionResult Index()
        {

            return View();
        }

        //public ActionResult Data()
        //{
        //    var currentUserId = User.Identity.GetUserId();
        //    var roadmapID = (from p in db.Profiles
        //                     where p.Id == currentUserId
        //                     select p.RoadmapID);
        //    var mainsteps = (from m in db.Mainsteps
        //                     where m.RoadmapID == roadmapID
        //                     select m.MainstepName);
        //    var headings = (from h in db.Headings
        //                    where h.MainstepID == );
        //    var ViewModel = new ProfileStepViewModel
        //    {
        //        profile = (from p in db.Profiles
        //                   where p.Id == currentUserId
        //                   select p),
        //    mainsteps,
        //    headings,
        //    Substeps,
        //};
        //  return View(profiles.ToList());
        //}
        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}