using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Department
    {
        [Key]
        [Required]
        public int DepartmentId { get; set; }


        [Required(ErrorMessage = "Please Provide Code")]
        [Column(TypeName = "varchar")]
        [DisplayName("Code")]
        [StringLength(7, ErrorMessage = "Code Must Be 2-7 Characters Long", MinimumLength = 2)]
        [Remote("IsCodeExists", "SaveDepartment", ErrorMessage = "Code already  Exists!!")]
        public string DepartmentCode { get; set; }



        [Remote("IsNameExists", "SaveDepartment", ErrorMessage = " Name already  Exists!!")]
        [Required(ErrorMessage = "Please Provide Name")]
        [Column(TypeName = "varchar")]
        [DisplayName("Name")]


        public string DepartmentName { get; set; }


        public virtual List<Teacher> Teachers { get; set; } 
        public virtual List<Course> Courses { get; set; }
        public virtual List<Semester> Semesters { get; set; }

        public virtual List<Student> Students { get; set; }
        public virtual List<AssignCourse> AssignCourseList { get; set; }
        public virtual List<RoomAllocation> RoomAllocationList { get; set; }


    }
}