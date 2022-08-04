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
    public class TeachersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teachers
        public  ActionResult Index()
        {
            var Teachers = db.teachers.Include(r => r.city);
            return View(Teachers.ToList());
        }

        // GET: Teachers/Details/5
        public  ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            ViewBag.areaId = new SelectList(db.CityAreas, "Id", "Name");

            ViewBag.cityid = new SelectList(db.Cities, "Id", "Name");
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create( TeacherViewModel teacher, string ImageFile)
        {
            if (ModelState.IsValid)
            {

                
                string filename = Path.GetFileNameWithoutExtension(teacher.ImageFile.FileName);
                string extention = Path.GetExtension(teacher.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extention;
                teacher.ImagePath = "~/ImageStorage/" + filename;
                filename = Path.Combine(Server.MapPath("~/ImageStorage/"), filename);

                  teacher.ImageFile.SaveAs(filename);


                var myteacher = new Teacher {

                    Name = teacher.Name,
                    Email = teacher.Email,
                    Phone = teacher.Phone,
                    Password = teacher.Password,
                    Qualification  = teacher.Qualification,
                    Institute = teacher.Institute,
                    SecondQualification = teacher.SecondQualification,
                    SecondInstitute = teacher.SecondInstitute,
                    AboutMe = teacher.AboutMe,
                    TutoringType = teacher.TutoringType,
                    SkypId = teacher.SkypId,
                    Expertise = teacher.Expertise,
                    ImagePath= teacher.ImagePath,
                    LevelOfTaught=teacher.LevelOfTaught,
                    CityId=teacher.CityId


                };



                db.teachers.Add(myteacher);
                

                int[] cityArea = teacher.CityAreas_id;

                foreach (var areaid in cityArea)
                {
                    int i;

                    for(i=0; i<=cityArea.Length; i++)
                    {
                        if (i == areaid)
                        {
                            db.TeacherTOAreas.Add(new TeacherTOArea() {

                                TeacherId = teacher.TeacherId,
                                CityAreasId = i

                            });
                        }
                    }
                    
                }

              
                db.SaveChanges();
                
                return RedirectToAction("Edit");

             
            }

            return View(teacher);
        }



        public JsonResult GetAreasList(int cityId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<CityAreas> AreaList = db.CityAreas.Where(x => x.CityId == cityId).ToList();

            return Json(AreaList, JsonRequestBehavior.AllowGet);

        }


        // GET: Teachers1/Edit/5
        public ActionResult Edit()
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            // Teacher teacher = db.teachers.Find(id);
            //if (teacher == null)
            //{
            //  return HttpNotFound();
            // }



            // getting id  from teacher id
            Teacher teacher = db.teachers.OrderByDescending(p => p.TeacherId).First();
            int teacherId = teacher.TeacherId;

           // teacherId += 1 ;

            TeacherCourseViewModel t = new TeacherCourseViewModel();
            t.id = teacherId;




            var Result = from c in db.courses
                         select new
                         {
                             c.Id,
                             c.Title,
                             Checked = ((from ab in db.teacherToCourses
                                         where(ab.TeacherId == t.id) & (ab.CourseId==c.Id)
                                         select ab).Count() > 0)
                         };

            var myViewModel = new TeacherCourseViewModel();

            myViewModel.TeacherId = t.id;
            myViewModel.Name = teacher.Name;


            var MyCheckBoxList = new List<CourseCheckboxVIewModel>();

            foreach (var item in Result)
            {
                MyCheckBoxList.Add(new CourseCheckboxVIewModel {Id=item.Id, name=item.Title ,Checked=item.Checked  }); 
            }

            myViewModel.Courses = MyCheckBoxList;
            return View(myViewModel);
        }

         // POST: Teachers1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherCourseViewModel teacher)
        {
            if (ModelState.IsValid)
            {

                var myTeacher = db.teachers.Find(teacher.TeacherId);

               // myTeacher.Name = teacher.Name;


                foreach (var item in db.teacherToCourses)
                {
                    if(item.TeacherId == teacher.TeacherId)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in teacher.Courses)
                {
                    if (item.Checked)
                    {
                        db.teacherToCourses.Add(new TeacherToCourse() { TeacherId = teacher.TeacherId, CourseId = item.Id });
                    }
                }

               // db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        // GET: Teachers1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.teachers.Find(id);
            db.teachers.Remove(teacher);
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
