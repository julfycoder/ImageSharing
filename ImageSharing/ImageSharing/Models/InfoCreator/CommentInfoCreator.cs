﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.Models.EntityInfo;
using ImageSharing.DAL.Entity;
using ImageSharing.UserService;
using ImageSharing.TapeService;
using ImageSharing.PostService;
using ImageSharing.SubscriptionService;
using ImageSharing.CommentService;
using ImageSharing.FriendshipRequestService;
using ImageSharing.FriendshipService;

namespace ImageSharing.Models.InfoCreator
{
    public class CommentInfoCreator:EntityInfoCreator
    {
        public override EntityInfoBase Create(Entity entity,
            UserServiceClient userClient,
            PostServiceClient postClient,
            TapeServiceClient tapeClient,
            FriendshipServiceClient friendshipClient,
            CommentServiceClient commentClient,
            SubscriptionServiceClient subClient)
        {
            Comment comment = (Comment)entity;
            return new CommentInfo { ID = comment.ID, Text = comment.Text };
        }
    }
}