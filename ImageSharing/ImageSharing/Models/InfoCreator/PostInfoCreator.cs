using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.Models.EntityInfo;
using ImageSharing.DAL.Entity;
using ImageSharing.UserService;
using ImageSharing.TapeService;
using ImageSharing.PostService;
using ImageSharing.SubscriptionService;
using ImageSharing.CommentService;
using ImageSharing.FriendshipRequestService;
using ImageSharing.FriendshipService;

namespace ImageSharing.Models.InfoCreator
{
    public class PostInfoCreator : EntityInfoCreator
    {
        CommentInfoCreator commentInfoCreator = new CommentInfoCreator();
        CommentInfo CreateCommentInfo(Comment comment,
            UserServiceClient userClient,
            PostServiceClient postClient,
            TapeServiceClient tapeClient,
            FriendshipServiceClient friendshipClient,
            CommentServiceClient commentClient,
            SubscriptionServiceClient subClient)
        {
            return (CommentInfo)commentInfoCreator.Create(comment, userClient, postClient, tapeClient,friendshipClient,commentClient,subClient);
        }

        public override EntityInfoBase Create(Entity entity,
            UserServiceClient userClient,
            PostServiceClient postClient,
            TapeServiceClient tapeClient,
            FriendshipServiceClient friendshipClient,
            CommentServiceClient commentClient,
            SubscriptionServiceClient subClient)
        {
            Post post = (Post)entity;
            List<CommentInfo> comments = new List<CommentInfo>();
            IEnumerable<Comment> postComments = commentClient.GetComments().Where(c => c.PostID == post.ID);
            foreach (Comment comment in postComments) comments.Add(CreateCommentInfo(comment, userClient, postClient, tapeClient,friendshipClient,commentClient,subClient));
            return new PostInfo
            {
                ID = post.ID,
                DateTime = post.DateTime,
                Author = (PostAuthorInfo)new PostAuthorInfoCreator().Create(userClient.GetUser(post.AuthorID), userClient, postClient, tapeClient,friendshipClient,commentClient,subClient),
                ImageName = post.ImagePath,
                Comments = comments,
                Description = post.Description
            };
        }
    }
}