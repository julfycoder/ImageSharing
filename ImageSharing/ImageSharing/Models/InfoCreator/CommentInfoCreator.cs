using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.Models.EntityInfo;
using ImageSharing.DAL.Entity;

namespace ImageSharing.Models.InfoCreator
{
    public class CommentInfoCreator:EntityInfoCreator
    {
        public override EntityInfoBase Create(Entity entity, UserService.UserServiceClient userClient, PostService.PostServiceClient postClient, TapeService.TapeServiceClient tapeClient)
        {
            Comment comment = (Comment)entity;
            return new CommentInfo { ID = comment.ID, Text = comment.Text };
        }
    }
}