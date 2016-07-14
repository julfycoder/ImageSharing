using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.Models.EntityInfo;
using ImageSharing.UserService;
using ImageSharing.TapeService;
using ImageSharing.PostService;
using ImageSharing.SubscriptionService;
using ImageSharing.CommentService;
using ImageSharing.FriendshipRequestService;
using ImageSharing.DAL.Entity;

namespace ImageSharing.Models.InfoCreator
{
    public abstract class EntityInfoCreator
    {
        public abstract EntityInfoBase Create(Entity entity, UserServiceClient userClient, PostServiceClient postClient, TapeServiceClient tapeClient);
    }
}