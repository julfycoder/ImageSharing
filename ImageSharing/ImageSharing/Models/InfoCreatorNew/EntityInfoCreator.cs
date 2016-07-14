using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.Models.EntityInfo;
using ImageSharing.UserServiceNew;
using ImageSharing.TapeServiceNew;
using ImageSharing.PostServiceNew;
using ImageSharing.SubscriptionServiceNew;
using ImageSharing.CommentServiceNew;
using ImageSharing.FriendshipRequestServiceNew;
using ImageSharing.FriendshipService;
using ImageSharing.DAL.EntityNew;

namespace ImageSharing.Models.InfoCreatorNew
{
    public abstract class EntityInfoCreator
    {
        public abstract EntityInfoBase Create(Entity entity,
            UserServiceNewClient userClient,
            PostServiceNewClient postClient,
            TapeServiceNewClient tapeClient,
            FriendshipServiceClient friendshipClient,
            CommentServiceNewClient commentClient,
            SubscriptionServiceNewClient subClient);
    }
}