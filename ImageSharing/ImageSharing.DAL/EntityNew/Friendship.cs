using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageSharing.DAL.EntityNew
{
    public class Friendship:Entity
    {
        [ForeignKey("User1")]
        public int User1ID { get; set; }
        [ForeignKey("User2")]
        public int User2ID { get; set; }

        public UserAccount User1 { get; set; }
        public UserAccount User2 { get; set; }
    }
}
