using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Room
    {
         
        public int RoomId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [DisplayName("Room No.")]
        public string RoomNo { get; set; }

        public virtual List<RoomAllocation> RoomAllocationList { get; set; }
    }
}