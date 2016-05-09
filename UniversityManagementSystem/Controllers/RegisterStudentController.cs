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
    public class RegisterStudentController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: /RegisterStudent/
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Department);
            return View(students.ToList());
        }

        // GET: /RegisterStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: /RegisterStudent/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            return View();
        }

        // POST: /RegisterStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            string RegNo;
            if (ModelState.IsValid)
            {

                //====RegNo Generation====///
                Department aDepartment = db.Departments.Find(student.DepartmentId);
                List<Student> students = (from a in db.Students
                                          where ((a.DepartmentId == student.DepartmentId) && (a.Date.Year == student.Date.Year))
                                          select a).ToList();

                //string year = System.DateTime.Now.Year.ToString();
                string year = student.Date.Year.ToString();
                string DeptCode = aDepartment.DepartmentCode;
                int currentStudents = students.Count;
                if (currentStudents < 9)
                {
                    RegNo = DeptCode + "-" + year + "-00" + (++currentStudents);
                }
                else if (currentStudents >= 10 && currentStudents < 98)
                {
                    RegNo = DeptCode + "-" + year + "-0" + (++currentStudents);
                }
                else
                {
                    RegNo = DeptCode + "-" + year + "-" + (++currentStudents);

                }
                //====End of RegNo Generation====///

                student.RegNo = RegNo;
                db.Students.Add(student);
                db.SaveChanges();
                ViewBag.Message = "Student Save Successfully With Reg No  " + RegNo;
                //db.Students.Add(student);
                //db.SaveChanges();
               // return RedirectToAction("Create");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", student.DepartmentId);
            return View(student);
        }

        public JsonResult IsEmailExists(string Email)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            return Json(!db.Students.Any(x => x.Email == Email), JsonRequestBehavior.AllowGet);
        }

        // GET: /RegisterStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            return View(student);
        }

        // POST: /RegisterStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="StudentId,RegNo,Name,Email,ContactNO,Date,Address,DepartmentId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            return View(student);
        }

        // GET: /RegisterStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /RegisterStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
