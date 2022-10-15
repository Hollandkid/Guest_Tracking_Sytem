using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guest_Tracking_System.Models
{
    public class BranchVM
    {
        public List<Branch> Branches { get; set; }
        public List<ApplicationUser> Staffs { get; set; }
        public int totalBranch { get; set; }
        public int branchId { get; set; }
        public string staffEmail { get; set; }

    }
}
