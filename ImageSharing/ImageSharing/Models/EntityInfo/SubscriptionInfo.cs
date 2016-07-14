using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageSharing.Models.EntityInfo
{
    public class SubscriptionInfo:EntityInfoBase
    {
        public string UserName { get; set; }
        public string Surname { get; set; }
        public DateTime DateTime { get; set; }
        public int friendId { get; set; }
        public int PostsCount { get; set; }
    }
}