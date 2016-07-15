using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImageSharing.Models
{
    public class ChangeAccountModel
    {
        [Required]
        [Display(Name = "Name\t")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname\t")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Email\t")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password\t")]
        public string Password { get; set; }

        public string AvatarPath { get; set; }
    }
}