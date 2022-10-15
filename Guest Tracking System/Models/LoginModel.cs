using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Guest_Tracking_System.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email Address is Required")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        public virtual string Password { get; set; }

    }
}
