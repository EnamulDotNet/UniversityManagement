using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseEnrollController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: /CourseEnroll/
        public ActionResult Index()
        {
            var courseenrolls = db.CourseEnrolls.Include(c => c.Course);
            return View(courseenrolls.ToList());
        }

        // GET: /CourseEnroll/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEnroll courseenroll = db.CourseEnrolls.Find(id);
            if (courseenroll == null)
            {
                return HttpNotFound();
            }
            return View(courseenroll);
        }

        // GET: /CourseEnroll/Create
        public ActionResult Create()
        {
            List<Course> Courselist = (from acourse in db.Courses
                                       select acourse).ToList();
            ViewBag.CourseId = new SelectList(Courselist, "CourseId", "CourseCode");

            List<Student> std = new List<Student>();
            std = (from st in db.Students
                   select st).ToList();
            ViewBag.StudentRegNo = new SelectList(std, "StudentId", "RegNo");
            return View();
        }

        // POST: /CourseEnroll/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseEnroll courseenroll)
        {



            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");

            List<Student> std = new List<Student>();
            std = (from st in db.Students
                   select st).ToList();
            ViewBag.StudentRegNo = new SelectList(std, "StudentId", "RegNo");
            try
            {

                if (ModelState.IsValid)
                {
                    List<CourseEnroll> enrollCourseList = new List<CourseEnroll>();
                    enrollCourseList = (from acourse in db.CourseEnrolls
                                        where
                                            (acourse.CourseId == courseenroll.CourseId) &&
                                            (acourse.StudentRegNo == courseenroll.StudentRegNo)
                                        select acourse).ToList();
                    if (enrollCourseList.Count <= 0)
                    {
                        db.CourseEnrolls.Add(courseenroll);
                        db.SaveChanges();
                        ViewBag.message = "Save Successfully";
                    }
                    else
                    {
                        ViewBag.message = "This Course Already Enroll";
                    }
                    //return RedirectToAction("Create");
                }

            }
            catch (Exception)
            {
                ViewBag.message = "Failed To Enroll.";
            }


            return View();
        }

        // GET: /CourseEnroll/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEnroll courseenroll = db.CourseEnrolls.Find(id);
            if (courseenroll == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", courseenroll.CourseId);
            return View(courseenroll);
        }

        // POST: /CourseEnroll/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CourseEnrollId,StudentRegNo,CourseId,EnrollDate")] CourseEnroll courseenroll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseenroll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", courseenroll.CourseId);
            return View(courseenroll);
        }

        // GET: /CourseEnroll/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEnroll courseenroll = db.CourseEnrolls.Find(id);
            if (courseenroll == null)
            {
                return HttpNotFound();
            }
            return View(courseenroll);
        }

        // POST: /CourseEnroll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseEnroll courseenroll = db.CourseEnrolls.Find(id);
            db.CourseEnrolls.Remove(courseenroll);
            db.SaveChanges();
            return RedirectToAction("Index");
        }






        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetStudentEnrollInfo(int selectStudentId)
        {
            List<Student> studentList = (from a in db.Students
                                         join c in db.Departments on a.DepartmentId equals c.DepartmentId
                                         where a.StudentId == selectStudentId
                                         select a).ToList();
            var stdEnrollInfo = new
            {
                // n = m.Name,
                name = studentList[0].Name,
                email = studentList[0].Email,
                deptname = studentList[0].Department.DepartmentName,


            };
            return Json(stdEnrollInfo, JsonRequestBehavior.AllowGet);
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
