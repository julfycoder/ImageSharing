using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageSharing.Models
{
    public class CommentationModel
    {
        public int PostID { get; set; }
        public string Comment { get; set; }
    }
}