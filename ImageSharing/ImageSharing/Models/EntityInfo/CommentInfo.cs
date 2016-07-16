using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ImageSharing.LocalResource;

namespace ImageSharing.Models.EntityInfo
{
    public class CommentInfo : EntityInfoBase
    {
        [Display(Name = "Text", ResourceType = typeof(Resource))]
        public string Text { get; set; }
    }
}