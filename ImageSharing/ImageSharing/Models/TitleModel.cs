using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ImageSharing.LocalResource;

namespace ImageSharing.Models
{
    public class TitleModel
    {
        [Display(Name="Recover",ResourceType=typeof(Resource))]
        public string Recover { get; set; }

        [Display(Name = "Register", ResourceType = typeof(Resource))]
        public string Register { get; set; }

        [Display(Name = "Login", ResourceType = typeof(Resource))]
        public string Login { get; set; }
    }
}