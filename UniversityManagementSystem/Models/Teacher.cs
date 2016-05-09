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
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Remote("CheckEmailUniqueness", "SaveTeacher", ErrorMessage = "Email Must be Unique")]
        [Display(Name = "Email address")]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Contact number is required!!")]
        [Column(TypeName = "varchar")]
        public string ContactNo { set; get; }

 
        [DisplayName("Department")]
        [Required(ErrorMessage = "Department can't be empty")]
        public virtual int DepartmentId { set; get; }
        
        [DisplayName("Designation")]
        [Required(ErrorMessage = "Designation can't be empty")]
        public virtual int DesignationId { set; get; }


        public virtual Designation Designation { set; get; }
        public virtual Department Department { set; get; }
        [Required]
        [Range(0,500,ErrorMessage = "Must be Non negative")]
        [DisplayName("Credit to be taken")]
        public double CreditToBeTaken { set; get; }

        public virtual List<AssignCourse> AssignCourseList { get; set; }
    }
}