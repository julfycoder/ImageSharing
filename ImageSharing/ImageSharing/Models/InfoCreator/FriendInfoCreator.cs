using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.Models.EntityInfo;
using ImageSharing.DAL.Entity;

namespace ImageSharing.Models.InfoCreator
{
    public class FriendInfoCreator:EntityInfoCreator
    {
        public override EntityInfoBase Create(Entity entity, UserService.UserServiceClient userClient, PostService.PostServiceClient postClient, TapeService.TapeServiceClient tapeClient)
        {
            UserAccount friend = (UserAccount)entity;
            return new FriendInfo
            {
                ID = friend.ID,
                Name = friend.Name,
                Surname = friend.Surname,
                AvatarPath = friend.AvatarPath
            };
        }
    }
}