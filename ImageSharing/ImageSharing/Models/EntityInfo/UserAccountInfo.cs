using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ImageSharing.LocalResource;

namespace ImageSharing.Models.EntityInfo
{
    public class UserAccountInfo:EntityInfoBase
    {
        [Required]
        [Display(Name="Name",ResourceType=typeof(Resource))]
        public string Name { get; set; }
        [Display(Name = "Surname", ResourceType = typeof(Resource))]
        public string Surname{get;set;}
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }
        [Display(Name = "Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }
        [Display(Name = "AvatarName", ResourceType = typeof(Resource))]
        public string AvatarName { get; set; }
        public TapeInfo Tape { get; set; }
        public IEnumerable<FriendInfo> Friends { get; set; }
        public IEnumerable<SubscriptionInfo> Subscriptions { get; set; }
        [Display(Name = "Role", ResourceType = typeof(Resource))]
        public string Role { get; set; }
    }
}