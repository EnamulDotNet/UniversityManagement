using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Grade
    {


        public int GradeId { get; set; }

        [DisplayName("Grade Letter")]
        [Required(ErrorMessage = "Grade Letter Field is required")]
         
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual List<ResultEntry> ResultEntryList { get; set; }
    }
}