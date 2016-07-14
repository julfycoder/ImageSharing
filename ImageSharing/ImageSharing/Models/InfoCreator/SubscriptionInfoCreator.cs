using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.Models.EntityInfo;
using ImageSharing.UserService;
using ImageSharing.PostService;
using ImageSharing.DAL.Entity;

namespace ImageSharing.Models.InfoCreator
{
    public class SubscriptionInfoCreator:EntityInfoCreator
    {
        public override EntityInfoBase Create(Entity entity, UserServiceClient userClient, PostServiceClient postClient, TapeService.TapeServiceClient tapeClient)
        {
            Subscription subscription = (Subscription)entity;
            return new SubscriptionInfo
            {
                ID = subscription.ID,
                UserName = userClient.GetUser(subscription.UserId).Name,
                Surname = userClient.GetUser(subscription.UserId).Surname,
                PostsCount = postClient.GetPosts().Where(p => p.AuthorID == subscription.UserId && p.DateTime > subscription.DateTime).Count(),
                DateTime = subscription.DateTime,
                friendId = subscription.UserId
            };
        }
    }
}