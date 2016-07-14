using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSharing.DAL.Entity
{
    public class Post:Entity
    {
        public string IDsComments { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateTime { get; set; }
        public int AuthorID { get; set; }
        public string Description { get; set; }
    }
}
