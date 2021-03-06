﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ImageSharing.LocalResource;

namespace ImageSharing.Models
{
    public class ActionModel
    {
        [Display(Name = "Action", ResourceType = typeof(Resource))]
        public string Action { get; set; }

        [Display(Name="AddAction",ResourceType=typeof(Resource))]
        public string Add { get; set; }

        [Display(Name = "DeleteAction", ResourceType = typeof(Resource))]
        public string Delete { get; set; }

        [Display(Name = "SaveAction", ResourceType = typeof(Resource))]
        public string Save { get; set; }

        [Display(Name = "UploadAction", ResourceType = typeof(Resource))]
        public string Upload { get; set; }

        [Display(Name = "LoginAction", ResourceType = typeof(Resource))]
        public string Login { get; set; }

        [Display(Name = "RegisterAction", ResourceType = typeof(Resource))]
        public string Register { get; set; }

        [Display(Name = "SearchAction", ResourceType = typeof(Resource))]
        public string Search { get; set; }

        [Display(Name = "UsersAction", ResourceType = typeof(Resource))]
        public string Users { get; set; }

        [Display(Name = "ChangeAction", ResourceType = typeof(Resource))]
        public string Change { get; set; }

        [Display(Name = "CommentsAction", ResourceType = typeof(Resource))]
        public string Comments { get; set; }

        [Display(Name = "PostsAction", ResourceType = typeof(Resource))]
        public string Posts { get; set; }

        [Display(Name = "RequestsAction", ResourceType = typeof(Resource))]
        public string Requests { get; set; }

        [Display(Name = "Follow", ResourceType = typeof(Resource))]
        public string Follow { get; set; }

        [Display(Name = "Unfollow", ResourceType = typeof(Resource))]
        public string Unfollow { get; set; }

        [Display(Name = "MakeFriend", ResourceType = typeof(Resource))]
        public string MakeFriend { get; set; }

        [Display(Name = "RemoveFriend", ResourceType = typeof(Resource))]
        public string RemoveFriend { get; set; }

        [Display(Name = "SendAction", ResourceType = typeof(Resource))]
        public string Send { get; set; }
    }
}