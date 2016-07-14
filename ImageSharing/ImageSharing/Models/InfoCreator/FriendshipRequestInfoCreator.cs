using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.DAL.Entity;
using ImageSharing.Models.EntityInfo;

namespace ImageSharing.Models.InfoCreator
{
    public class FriendshipRequestInfoCreator:EntityInfoCreator
    {
        public override EntityInfoBase Create(Entity entity, UserService.UserServiceClient userClient, PostService.PostServiceClient postClient, TapeService.TapeServiceClient tapeClient)
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