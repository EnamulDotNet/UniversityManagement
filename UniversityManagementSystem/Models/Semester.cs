using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }

        [DisplayName("Semester")]
        [Required(ErrorMessage = "Semester Field is required")]
        [Column(TypeName = "varchar")]
        public string SemesterName { get; set; }

        public virtual List<Course> Courses { get; set; } 
    }
}