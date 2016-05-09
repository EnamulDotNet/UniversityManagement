using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class ResultEntry
    {

        public int ResultEntryId { get; set; }

        [Required(ErrorMessage = "Student can't be empty")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [Required(ErrorMessage = "Course can't be empty")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Required(ErrorMessage = "Grade can't be empty")]
        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }
    }
}