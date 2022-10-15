using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guest_Tracking_System.Models
{
    public class GuestViewModel
    {
        public List<GuestDeatils> Guests { get; set; }
        public int totalGuest { get; set; }
        public int totalInHouseGuest { get; set; }
    }
}
