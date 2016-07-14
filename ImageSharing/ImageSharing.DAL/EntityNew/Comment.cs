using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageSharing.DAL.EntityNew
{
    public class Comment:Entity
    {
        [ForeignKey("Post")]
        public int PostID { get; set; }
        public string Text { get; set; }

        public Post Post { get; set; }
    }
}
