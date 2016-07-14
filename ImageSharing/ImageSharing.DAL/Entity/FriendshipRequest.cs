using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSharing.DAL.Entity
{
    public class FriendshipRequest:Entity
    {
        public int AskerID { get; set; }
        public int DestinationID { get; set; }
    }
}
