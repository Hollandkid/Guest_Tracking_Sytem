using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Guest_Tracking_System.Models
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "Full name is Required")]
        [Display(Name = "Full Name")]
        public string Fullname { get; set; }


        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Address is Required")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Address is Required")]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Phone Number is Required")]
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }


        [Required(ErrorMessage = "Admin Type is Required")]
        public string Role { get; set; }

        public string Image { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        public virtual string Password { get; set; }

    }
}
