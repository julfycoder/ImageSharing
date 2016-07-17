using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ImageSharing.LocalResource;

namespace ImageSharing.Models
{
    public class InformationModel
    {
        [Display(Name = "PolicyInformation", ResourceType = typeof(Resource))]
        public string PolicyInformation { get; set; }

        [Display(Name = "AboutInformation", ResourceType = typeof(Resource))]
        public string AboutInformation { get; set; }
    }
}