using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Guest_Tracking_System.Models
{
    public class GuestDeatils
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string GuestIdNo { get; set; }

        [Required]
        public string Address { get; set; } 
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public string VisitPurpose { get; set; }

        [Required]
        public string WhomtoSee { get; set; }

        [Required]
        public string ArrivalTime { get; set; }

        public string DepartureTime { get; set; }

        [Required]
        public string PhoneNo{ get; set; }
        //public int Price { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    }
}
