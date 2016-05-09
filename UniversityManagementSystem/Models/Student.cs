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
    public class Student
    {

        [Key]
        public int StudentId { get; set; }
        [Column(TypeName = "varchar")]
        [DisplayName("")]
        public string RegNo { get; set; }
        [Required(ErrorMessage = "Please provide Name")]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide Email")]
        [Column(TypeName = "varchar")]
        [Remote("IsEmailExists", "RegisterStudent", ErrorMessage = " Email already  Exists!!")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide Contact No")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{5})$", ErrorMessage = "Enter valid Phone Number")]
        [DisplayName("Contact No")]
        [Column(TypeName = "varchar")]
         [MaxLength(14,ErrorMessage = "Must be 14 character long")]
        public string ContactNO { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { set; get; }
        [Required]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { set; get; }
        public virtual List<ResultEntry> ResultEntryList { get; set; }
    }
}