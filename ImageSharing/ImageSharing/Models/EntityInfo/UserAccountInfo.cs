using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageSharing.Models.EntityInfo
{
    public class UserAccountInfo:EntityInfoBase
    {
        public string Name { get; set; }
        public string Surname{get;set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarPath { get; set; }
        public TapeInfo Tape { get; set; }
        public IEnumerable<FriendInfo> Friends { get; set; }
        public IEnumerable<SubscriptionInfo> Subscriptions { get; set; }
        public string Role { get; set; }
    }
}