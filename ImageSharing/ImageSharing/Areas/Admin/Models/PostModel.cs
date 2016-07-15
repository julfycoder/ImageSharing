using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageSharing.Areas.Admin.Models
{
    public class PostModel
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateTime { get; set; }
        public int AuthorID { get; set; }
        public string Description { get; set; }
    }
}