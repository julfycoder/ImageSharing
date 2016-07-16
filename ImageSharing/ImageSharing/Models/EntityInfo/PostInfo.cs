using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ImageSharing.LocalResource;

namespace ImageSharing.Models.EntityInfo
{
    public class PostInfo:EntityInfoBase
    {
        [Display(Name = "PostID", ResourceType = typeof(Resource))]
        public int PostID { get; set; }
        [Display(Name = "ImageName", ResourceType = typeof(Resource))]
        public string ImageName { get; set; }
        [Display(Name = "DateTime", ResourceType = typeof(Resource))]
        public DateTime DateTime { get; set; }
        [Display(Name = "Author", ResourceType = typeof(Resource))]
        public PostAuthorInfo Author { get; set; }
        public IEnumerable<CommentInfo> Comments { get; set; }
        [Display(Name = "Description", ResourceType = typeof(Resource))]
        public string Description { get; set; }
    }
}