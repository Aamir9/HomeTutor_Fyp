using HomeTutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace HomeTutor.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
           ViewBag.cityid = new SelectList(db.Cities, "Id", "Name");
            return View();
        }


        
        public ActionResult Search()
        {

            //var Teachers = from m in db.teachers select m;
            //if (!String.IsNullOrEmpty(teacher.LevelOfTaught))
            //{
            //    Teachers = Teachers.Where(s => s.LevelOfTaught.Contains(teacher.LevelOfTaught));
            //}

            var Teachers = db.teachers.Include(r => r.city);

            //var Resuls = from a in db.CityAreas
            //             select new
            //             {
            //                 a.Id,
            //                 a.Name,
            //                 AreaList=((from  at in db.TeacherTOAreas
            //                            where (at.TeacherId== ))

                       //  };

            InfoViewModel myViewModel = new InfoViewModel();
            myViewModel.Teachers = Teachers;


            var myarealsit = new List<CityAreaVewModel>();

            return View(myViewModel);


            

        }


       

        public JsonResult GetAreasList(int cityId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<CityAreas> AreaList = db.CityAreas.Where(x => x.CityId == cityId).ToList();

            return Json(AreaList, JsonRequestBehavior.AllowGet);

        }
    }
}