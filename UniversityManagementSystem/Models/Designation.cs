using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }
        [Column(TypeName = "varchar")]
        public string DesignationName { get; set; }
    }
}