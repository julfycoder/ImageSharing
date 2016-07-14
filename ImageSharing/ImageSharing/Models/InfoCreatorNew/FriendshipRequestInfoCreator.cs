using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.DAL.EntityNew;
using ImageSharing.Models.EntityInfo;
using ImageSharing.UserServiceNew;
using ImageSharing.TapeServiceNew;
using ImageSharing.PostServiceNew;
using ImageSharing.SubscriptionServiceNew;
using ImageSharing.CommentServiceNew;
using ImageSharing.FriendshipRequestServiceNew;
using ImageSharing.FriendshipService;

namespace ImageSharing.Models.InfoCreatorNew
{
    public class FriendshipRequestInfoCreator:EntityInfoCreator
    {
        public override EntityInfoBase Create(Entity entity, UserServiceNewClient userClient, PostServiceNewClient postClient, TapeServiceNewClient tapeClient, FriendshipServiceClient friendshipClient, CommentServiceNewClient commentClient, SubscriptionServiceNewClient subClient)
        {
            FriendshipRequest request = (FriendshipRequest)entity;
            return new FriendshipRequestInfo
            {
                ID = request.ID,
                AskerID = request.AskerID,
                DestinationID = request.DestinationID
            };
        }
    }
}