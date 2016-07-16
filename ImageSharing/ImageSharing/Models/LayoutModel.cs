using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ImageSharing.LocalResource;

namespace ImageSharing.Models
{
    public class LayoutModel
    {
        [Display(Name = "Home", ResourceType = typeof(Resource))]
        public string Home { get; set; }

        [Display(Name = "Friends", ResourceType = typeof(Resource))]
        public string Friends { get; set; }

        [Display(Name = "Account", ResourceType = typeof(Resource))]
        public string Account { get; set; }

        [Display(Name = "About", ResourceType = typeof(Resource))]
        public string About { get; set; }

        [Display(Name = "Policy", ResourceType = typeof(Resource))]
        public string Policy { get; set; }

        [Display(Name = "Administration", ResourceType = typeof(Resource))]
        public string Administration { get; set; }

        [Display(Name = "Subscriptions", ResourceType = typeof(Resource))]
        public string Subscriptions { get; set; }

        [Display(Name = "Logout", ResourceType = typeof(Resource))]
        public string Logout { get; set; }

        [Display(Name = "Login", ResourceType = typeof(Resource))]
        public string Login { get; set; }

        [Display(Name = "Register", ResourceType = typeof(Resource))]
        public string Register { get; set; }
    }
}