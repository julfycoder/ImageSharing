using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageSharing.Areas.Admin.Models
{
    public class CommentModel
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public string Text { get; set; }
    }
}