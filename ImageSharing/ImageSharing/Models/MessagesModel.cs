using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ImageSharing.LocalResource;

namespace ImageSharing.Models
{
    public class MessagesModel
    {
        [Display(Name="EmailMessage",ResourceType=typeof(Resource))]
        public string EmailMessage { get; set; }
    }
}