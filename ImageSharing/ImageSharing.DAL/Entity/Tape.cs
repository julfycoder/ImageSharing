using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageSharing.DAL.Entity
{
    public class Tape:Entity
    {
        [ForeignKey("UserAccount")]
        public int UserID { get; set; }

        public UserAccount UserAccount { get; set; }
    }
}
