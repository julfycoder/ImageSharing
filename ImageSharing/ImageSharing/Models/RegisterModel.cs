using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ImageSharing.LocalResource;

namespace ImageSharing.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Name", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm", ResourceType = typeof(Resource))]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Avatar", ResourceType = typeof(Resource))]
        public string AvatarPath { get; set; }

        [Required]
        [Display(Name = "Role", ResourceType = typeof(Resource))]
        public string Role { get; set; }
    }
}