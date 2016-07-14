using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageSharing.Models.EntityInfo
{
    public class FriendshipRequestInfo:EntityInfoBase
    {
        public int AskerID { get; set; }
        public int DestinationID { get; set; }
    }
}