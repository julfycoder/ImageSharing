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
    public class TapeInfoCreator : EntityInfoCreator
    {
        PostInfoCreator postInfoCreator = new PostInfoCreator();
        PostInfo CreatePostInfo(Post post,
            UserServiceClient userClient,
            PostServiceClient postClient,
            TapeServiceClient tapeClient,
            FriendshipServiceClient friendshipClient,
            CommentServiceClient commentClient,
            SubscriptionServiceClient subClient)
        {
            return (PostInfo)postInfoCreator.Create(post, userClient, postClient, tapeClient, friendshipClient, commentClient,subClient);
        }

        public override EntityInfoBase Create(Entity entity,
            UserServiceClient userClient,
            PostServiceClient postClient,
            TapeServiceClient tapeClient,
            FriendshipServiceClient friendshipClient,
            CommentServiceClient commentClient,
            SubscriptionServiceClient subClient)
        {
            Tape tape = (Tape)entity;
            List<PostInfo> posts = new List<PostInfo>();
            IEnumerable<Post> tapePosts = postClient.GetPosts().Where(p => p.TapeID == tape.ID);
            foreach (Post post in tapePosts) posts.Add(CreatePostInfo(post, userClient, postClient, tapeClient,  friendshipClient,commentClient,subClient));
            return new TapeInfo
            {
                ID = tape.ID,
                Posts = posts
            };
        }
    }
}