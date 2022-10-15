using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Guest_Tracking_System.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string StaffEmail { get; set; }

        [Required]
        public string BranchName { get; set; }

        [Required]
        public string BranchContact { get; set; }
        
        [Required]
        public string BranchEmail { get; set; }

        [Required]
        public string BranchAddress { get; set; }
    }
}
