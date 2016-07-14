using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImageSharing.Models
{
    public class LoginModel
    {
        [Display(Name="Email\t")]
        public string Email { get; set; }

        [Display(Name = "Password\t")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}