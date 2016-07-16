using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ImageSharing.LocalResource;

namespace ImageSharing.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [Display(Name = "Forgot_your_password", ResourceType = typeof(Resource))]
        public string Forgot_your_password { get; set; }

        public bool RememberMe { get; set; }
    }
}