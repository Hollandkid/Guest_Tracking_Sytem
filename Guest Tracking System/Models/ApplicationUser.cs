using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guest_Tracking_System.Models
{
    public class ApplicationUser :IdentityUser
    {

        public string Fullname { get; set; }
      
        public virtual string Password { get; set; }

        public string Address { get; set; }
        public string Role { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public int BranchId { get; set; }

    }
}
