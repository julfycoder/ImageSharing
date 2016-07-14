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
    public class SubscriptionInfoCreator:EntityInfoCreator
    {
        public override EntityInfoBase Create(Entity entity, UserServiceNewClient userClient, PostServiceNewClient postClient, TapeServiceNewClient tapeClient, FriendshipServiceClient friendshipClient, CommentServiceNewClient commentClient, SubscriptionServiceNewClient subClient)
        {
            Subscription subscription = (Subscription)entity;
            return new SubscriptionInfo
            {
                ID = subscription.ID,
                UserName = userClient.GetUser(subscription.UserID).Name,
                Surname = userClient.GetUser(subscription.UserID).Surname,
                PostsCount = postClient.GetPosts().Where(p => p.AuthorID == subscription.UserID && p.DateTime > subscription.DateTime).Count(),
                DateTime = subscription.DateTime,
                friendId = subscription.UserID
            };
        }
    }
}