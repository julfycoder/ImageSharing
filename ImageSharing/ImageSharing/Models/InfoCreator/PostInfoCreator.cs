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
    public class PostInfoCreator : EntityInfoCreator
    {
        CommentInfoCreator commentInfoCreator = new CommentInfoCreator();
        CommentInfo CreateCommentInfo(Comment comment, UserServiceClient userClient, PostServiceClient postClient, TapeService.TapeServiceClient tapeClient)
        {
            return (CommentInfo)commentInfoCreator.Create(comment, userClient, postClient, tapeClient);
        }

        public override EntityInfoBase Create(Entity entity, UserServiceClient userClient, PostServiceClient postClient, TapeService.TapeServiceClient tapeClient)
        {
            Post post = (Post)entity;
            List<CommentInfo> comments = new List<CommentInfo>();
            IEnumerable<Comment> postComments = postClient.GetComments(post.ID);
            foreach (Comment comment in postComments) comments.Add(CreateCommentInfo(comment, userClient, postClient, tapeClient));
            return new PostInfo
            {
                ID = post.ID,
                DateTime = post.DateTime,
                Author = (PostAuthorInfo)new PostAuthorInfoCreator().Create(userClient.GetUser(post.AuthorID), userClient, postClient, tapeClient),
                ImagePath = post.ImagePath,
                Comments = comments,
                Description = post.Description
            };
        }
    }
}