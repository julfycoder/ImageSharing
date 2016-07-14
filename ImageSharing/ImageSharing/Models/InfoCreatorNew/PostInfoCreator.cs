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
    public class PostInfoCreator : EntityInfoCreator
    {
        CommentInfoCreator commentInfoCreator = new CommentInfoCreator();
        CommentInfo CreateCommentInfo(Comment comment, UserServiceNewClient userClient, PostServiceNewClient postClient, TapeServiceNewClient tapeClient, FriendshipServiceClient friendshipClient, CommentServiceNewClient commentClient, SubscriptionServiceNewClient subClient)
        {
            return (CommentInfo)commentInfoCreator.Create(comment, userClient, postClient, tapeClient,friendshipClient,commentClient,subClient);
        }

        public override EntityInfoBase Create(Entity entity, UserServiceNewClient userClient, PostServiceNewClient postClient, TapeServiceNewClient tapeClient, FriendshipServiceClient friendshipClient, CommentServiceNewClient commentClient, SubscriptionServiceNewClient subClient)
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
                ImagePath = post.ImagePath,
                Comments = comments,
                Description = post.Description
            };
        }
    }
}