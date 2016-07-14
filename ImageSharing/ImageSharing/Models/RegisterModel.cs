using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImageSharing.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Name\t")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname\t")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Email\t")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password\t")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password\t")]
        [Compare("Confirm password", ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Avatar\t")]
        public string AvatarPath { get; set; }
    }
}