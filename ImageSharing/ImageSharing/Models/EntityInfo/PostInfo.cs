using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageSharing.Models.EntityInfo
{
    public class PostInfo:EntityInfoBase
    {
        public string ImagePath { get; set; }
        public DateTime DateTime { get; set; }
        public PostAuthorInfo Author { get; set; }
        public IEnumerable<CommentInfo> Comments { get; set; }
        public string Description { get; set; }
    }
}