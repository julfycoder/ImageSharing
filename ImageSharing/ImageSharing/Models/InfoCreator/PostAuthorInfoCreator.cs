using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.Models.EntityInfo;
using ImageSharing.DAL.Entity;

namespace ImageSharing.Models.InfoCreator
{
    public class PostAuthorInfoCreator:EntityInfoCreator
    {
        public override EntityInfoBase Create(Entity entity, UserService.UserServiceClient userClient, PostService.PostServiceClient postClient, TapeService.TapeServiceClient tapeClient)
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