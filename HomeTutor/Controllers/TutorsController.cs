using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeTutor.Models;
using System.IO;

namespace HomeTutor.Controllers
{
    public class TutorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tutors
        public ActionResult Index()
        {
            var tutors = db.tutors.Include(r => r.city).Include(r=>r.Areas);
            return View(tutors.ToList());
        }

        // GET: Tutors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = await db.tutors.FindAsync(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // GET: Tutors/Create
        public ActionResult Create()
        {
            ViewBag.cityId = new SelectList(db.Cities, "Id", "Name");

            //Tutor tutor = db.tutors.OrderByDescending(p => p.TutorId).First();
            //int TutorId = tutor.TutorId;

            //TutorId +=1 ;

            //Tutor tur = new Tutor();
            //tur.TutorId = TutorId;


            return View();
        }

        // POST: Tutors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tutor tutor, string ImageFile )
        {
            if (ModelState.IsValid)
            {

                string filename = Path.GetFileNameWithoutExtension(tutor.ImageFile.FileName);
                string extention = Path.GetExtension(tutor.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extention;
                tutor.ImagePath = "~/ImageStorage/" + filename;
                filename = Path.Combine(Server.MapPath("~/ImageStorage/"), filename);

                 tutor.ImageFile.SaveAs(filename);

               


                db.tutors.Add(tutor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
              ViewBag.cityId = new SelectList(db.Cities, "Id", "Name", tutor.CityId);

            
          
           
            return View(tutor);
        }


        public JsonResult GetAreasList(int cityId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<CityAreas> AreaList = db.CityAreas.Where(x => x.CityId == cityId).ToList();

            return Json(AreaList, JsonRequestBehavior.AllowGet);
            
        }


        //public JsonResult areaSave(string areaid , int tutorid)
        // {
        //    char[] myarea = { ',' };
            

        //    return Json(0, JsonRequestBehavior.AllowGet);
        //}







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
