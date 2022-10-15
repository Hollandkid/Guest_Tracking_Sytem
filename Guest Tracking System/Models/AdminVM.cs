using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guest_Tracking_System.Models
{
    public class AdminVM
    {
        public List<ApplicationUser> Users { get; set; }
        public int totalAdmin { get; set; }
        public int totalStaff { get; set; }
    }
}
