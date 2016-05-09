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
    public class AssignCourseController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");

            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignCourseId,DepartmentId,TeacherId,CreditToBeTaken,RemainingCredit,CourseId")] AssignCourse assigncourse)
        {
            if (ModelState.IsValid)
            {
                var result = db.AssignCourses.Count(r => r.CourseId == assigncourse.CourseId) == 0;

                if (result)
                {
                    Teacher aTeacher = db.Teachers.FirstOrDefault(t => t.TeacherId == assigncourse.TeacherId);

                    Course aCourse = db.Courses.FirstOrDefault(c => c.CourseId == assigncourse.CourseId);

                    List<AssignCourse> assignTeachers = db.AssignCourses.Where(t => t.TeacherId == assigncourse.TeacherId).ToList();

                    AssignCourse assign = null;

                    if (assignTeachers.Count != 0)
                    {
                        assign = assignTeachers.Last();

                        assigncourse.RemainingCredit = assign.RemainingCredit;
                    }
                    else
                    {
                        assigncourse.RemainingCredit = Convert.ToDouble(aTeacher.CreditToBeTaken);
                    }

                    if (assigncourse.RemainingCredit < aCourse.CourseCredit)
                    {
                        Session["Teacher"] = aTeacher;

                        Session["Course"] = aCourse;

                        Session["AssignedCourse"] = assigncourse;

                        Session["AssigneddCourseCheck"] = assign;

                        return RedirectToAction("AskToAssign");
                    }

                    assigncourse.CreditToBeTaken = aTeacher.CreditToBeTaken;

                    if (assign == null)
                    {
                        assigncourse.RemainingCredit = aTeacher.CreditToBeTaken - aCourse.CourseCredit;
                    }
                    else
                    {
                        assigncourse.RemainingCredit = assign.RemainingCredit - aCourse.CourseCredit;
                    }

                    aCourse.AssignTo = aTeacher.Name;

                    db.AssignCourses.Add(assigncourse);
                    db.SaveChanges();

                    TempData["success"] = "Course is Assigned";

                    return RedirectToAction("Create");
                }
                else
                {
                    TempData["Already"] = "Course Has Already Been Assigned";

                    return RedirectToAction("Create");
                }
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", assigncourse.CourseId);

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", assigncourse.DepartmentId);

            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name", assigncourse.TeacherId);

            return View(assigncourse);
        }

        public ActionResult AskToAssign()
        {
            Teacher aTeacher = (Teacher)Session["Teacher"];

            Course aCourse = (Course)Session["Course"];

            AssignCourse assign = (AssignCourse)Session["AssigneddCourseCheck"];

            double remainingCredite = 0.0;

            if (assign == null)
                remainingCredite = aTeacher.CreditToBeTaken;
            else
            {
                remainingCredite = assign.RemainingCredit;
            }

            if (remainingCredite < 0)
            {
                ViewBag.Message = aTeacher.Name + " Credit Limit Is Over. And The Course Credit  : " + aCourse.CourseCode + " Is " + aCourse.CourseCredit + "  ! Still You Want To Assign This Course To This Teacher ?";
            }
            else
            {
                ViewBag.Message = aTeacher.Name + " has only " + remainingCredite + " Credits Remaining . But, The Credit  : " + aCourse.CourseCode + " Is " + aCourse.CourseCredit + "  ! Still You Want To Assign This Course To This Teacher ?";
            }

            return View();
        }

        public ActionResult AssignConfirmed()
        {
            Teacher aTeacher = (Teacher)Session["Teacher"];

            AssignCourse assigncourse = (AssignCourse)Session["AssignedCourse"];

            AssignCourse assign = (AssignCourse)Session["AssigneddCourseCheck"];

            Course aCourse = db.Courses.FirstOrDefault(c => c.CourseId == assigncourse.CourseId);

            assigncourse.CreditToBeTaken = aTeacher.CreditToBeTaken;

            if (assign == null)
            {
                assigncourse.RemainingCredit = aTeacher.CreditToBeTaken - aCourse.CourseCredit;
            }
            else
            {
                assigncourse.RemainingCredit = assign.RemainingCredit - aCourse.CourseCredit;
            }

            aCourse.AssignTo = aTeacher.Name;

            db.AssignCourses.Add(assigncourse);
            db.SaveChanges();

            TempData["success"] = "Course Is Assigned";

            return View();
        }



        public ActionResult LoadTeacher(int? departmentId)
        {
            var teacherList = db.Teachers.Where(u => u.DepartmentId == departmentId).ToList();

            ViewBag.TeacherId = new SelectList(teacherList, "TeacherId", "Name");

            return PartialView("~/Views/Shared/_FillteredTeacher.cshtml");
        }

        public ActionResult LoadCourse(int? departmentId)
        {
            var courseList = db.Courses.Where(u => u.DepartmentId == departmentId).ToList();

            ViewBag.CourseId = new SelectList(courseList, "CourseId", "CourseCode");

            return PartialView("~/Views/shared/_FilteredCourse.cshtml");

        }

        public PartialViewResult TeacherInfoLoad(int? teacherId)
        {
            if (teacherId != null)
            {
                Teacher aTeacher = db.Teachers.FirstOrDefault(s => s.TeacherId == teacherId);

                ViewBag.Credit = aTeacher.CreditToBeTaken;

                List<AssignCourse> assignTeachers = db.AssignCourses.Where(t => t.TeacherId == teacherId).ToList();

                AssignCourse assign = null;

                if (assignTeachers.Count != 0)
                {
                    assign = assignTeachers.Last();
                }
                if (assign == null)
                {
                    ViewBag.RemainingCredit = aTeacher.CreditToBeTaken;
                }
                else
                {
                    ViewBag.RemainingCredit = assign.RemainingCredit;
                }

                return PartialView("~/Views/Shared/_TeachersCreditInfo.cshtml");
            }
            else
            {
                return PartialView("~/Views/Shared/_TeachersCreditInfo.cshtml");
            }

        }

        public PartialViewResult CourseInfoLoad(int? courseId)
        {
            if (courseId != null)
            {
                Course aCourse = db.Courses.FirstOrDefault(s => s.CourseId == courseId);

                ViewBag.Name = aCourse.CourseName;

                ViewBag.Credit = aCourse.CourseCredit;

                return PartialView("~/Views/Shared/_CourseInfo.cshtml");
            }
            else
            {
                return PartialView("~/Views/Shared/_CourseInfo.cshtml");
            }

        }

        public ActionResult ViewCourseStatics()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");

            return View();
        }

        public PartialViewResult CourseStaticsLoad(int? departmentId)
        {
            List<Course> courseList = new List<Course>();

            if (departmentId != null)
            {
                courseList = db.Courses.Where(r => r.DepartmentId == departmentId).ToList();

                if (courseList.Count == 0)
                {
                    ViewBag.NotAssigned = "Department Course is Empty";
                }
            }

            return PartialView("~/Views/shared/_coursestatics.cshtml", courseList);
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
