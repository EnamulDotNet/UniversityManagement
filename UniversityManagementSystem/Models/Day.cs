using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Day
    {
        

        public int DayId { get; set; }
        [DisplayName("Day")]
        [Column(TypeName = "varchar")]
        [Required]
        public string Name { get; set; }

        public virtual List<RoomAllocation> RoomAllocationList { get; set; }
    }
}