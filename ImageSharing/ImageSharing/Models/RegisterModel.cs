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
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname", ResourceType = typeof(Resource))]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
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