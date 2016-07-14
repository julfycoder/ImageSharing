using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageSharing.DAL.Entity
{
    public class FriendshipRequest:Entity
    {
        [ForeignKey("Asker")]
        public int AskerID { get; set; }
        [ForeignKey("Destination")]
        public int DestinationID { get; set; }

        public UserAccount Asker { get; set; }
        public UserAccount Destination { get; set; }
    }
}
