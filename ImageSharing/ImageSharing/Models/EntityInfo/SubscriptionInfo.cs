using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.LocalResource;
using System.ComponentModel.DataAnnotations;

namespace ImageSharing.Models.EntityInfo
{
    public class SubscriptionInfo:EntityInfoBase
    {
        [Display(Name="Name",ResourceType=typeof(Resource))]
        public string UserName { get; set; }
        [Display(Name = "Surname", ResourceType = typeof(Resource))]
        public string Surname { get; set; }
        public DateTime DateTime { get; set; }
        public int friendId { get; set; }
        [Display(Name = "PostsCount", ResourceType = typeof(Resource))]
        public int PostsCount { get; set; }
    }
}