using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageSharing.DAL.Entity
{
    public class Post:Entity
    {
        [ForeignKey("Tape")]
        public int TapeID { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateTime { get; set; }
        public int AuthorID { get; set; }
        public string Description { get; set; }

        public Tape Tape { get; set; }
    }
}
