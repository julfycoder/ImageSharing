using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.Models.EntityInfo;
using ImageSharing.DAL.EntityNew;
using ImageSharing.UserServiceNew;
using ImageSharing.TapeServiceNew;
using ImageSharing.PostServiceNew;
using ImageSharing.SubscriptionServiceNew;
using ImageSharing.CommentServiceNew;
using ImageSharing.FriendshipRequestServiceNew;
using ImageSharing.FriendshipService;

namespace ImageSharing.Models.InfoCreatorNew
{
    public class PostAuthorInfoCreator:EntityInfoCreator
    {
        public override EntityInfoBase Create(Entity entity, UserServiceNewClient userClient, PostServiceNewClient postClient, TapeServiceNewClient tapeClient, FriendshipServiceClient friendshipClient, CommentServiceNewClient commentClient, SubscriptionServiceNewClient subClient)
        {
            UserAccount author = (UserAccount)entity;
            return new PostAuthorInfo
            {
                ID = author.ID,
                Name = author.Name,
                Surname = author.Surname,
                AvatarPathInfo = author.AvatarPath
            };
        }
    }
}