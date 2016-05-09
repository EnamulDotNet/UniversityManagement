using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class CourseEnroll
    {

        public int CourseEnrollId { set; get; }
        [Required]
        public virtual int StudentRegNo { set; get; }
        [Required]
        public virtual int CourseId { set; get; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EnrollDate { set; get; }
        public virtual Student Student { set; get; }
        public virtual Course Course { set; get; }
        public virtual string GradeName { set; get; }
    }
}