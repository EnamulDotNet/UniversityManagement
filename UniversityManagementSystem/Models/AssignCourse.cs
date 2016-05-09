using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class AssignCourse
    {

        public int AssignCourseId { get; set; }

        [Required(ErrorMessage = "Department can't be empty")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [Required(ErrorMessage = "Teacher can't empty")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public virtual double CreditToBeTaken { get; set; }
        public virtual double RemainingCredit { get; set; }

        [Required(ErrorMessage = "Course can't empty")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}