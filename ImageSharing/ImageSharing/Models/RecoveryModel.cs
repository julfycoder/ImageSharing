using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImageSharing.Models
{
    public class RecoveryModel
    {
        [Display(Name="Email\t")]
        public string Email { get; set; }
    }
}