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
    public class Course
    {



         [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please Provide Code")]
        [Column(TypeName = "varchar")]
        [DisplayName("Code")]
        [StringLength(50,ErrorMessage = "Code Must be At least 5 char",MinimumLength = 5)]
        [Remote("IsCodeExists", "SaveCourse", ErrorMessage = "Code already  Exists!!")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Please Provide Name")]
        [Column(TypeName = "varchar")]
        [DisplayName("Name")]
        [Remote("IsNameExists", "SaveCourse", ErrorMessage = "Name already  Exists!!")]

        public string CourseName { get; set; }

        [Required(ErrorMessage = "Please Provide Credit")]
         
        [Range(0.5,5.0,ErrorMessage = "Credit must be 0.5-5.0")]
        [DisplayName("Credit")]
        public double CourseCredit { get; set; }

        [Required(ErrorMessage = " Please Provide Description")]
        [Column(TypeName = "varchar")]
        [DisplayName("Description")]

        public string CourseDescription { get; set; }
        [Required(ErrorMessage = "Select a department")]
        [Display(Name = "Department:")]

        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Select a Semester")]
        [Display(Name = "Department:")]
        public int SemesterId { get; set; }
        public virtual Department Department { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual String AssignTo { get; set; }
        
        public virtual List<RoomAllocation> RoomAllocationList { get; set; }
        public virtual List<ResultEntry> ResultEntryList { get; set; }

        public virtual List<AssignCourse> AssignCourseList { get; set; }


    }
}