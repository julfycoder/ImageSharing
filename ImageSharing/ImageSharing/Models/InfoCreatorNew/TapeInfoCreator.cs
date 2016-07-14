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
    public class TapeInfoCreator : EntityInfoCreator
    {
        PostInfoCreator postInfoCreator = new PostInfoCreator();
        PostInfo CreatePostInfo(Post post, UserServiceNewClient userClient, PostServiceNewClient postClient, TapeServiceNewClient tapeClient, CommentServiceNewClient commentClient, FriendshipServiceClient friendshipClient, SubscriptionServiceNewClient subClient)
        {
            return (PostInfo)postInfoCreator.Create(post, userClient, postClient, tapeClient, friendshipClient, commentClient,subClient);
        }

        public override EntityInfoBase Create(Entity entity, UserServiceNewClient userClient, PostServiceNewClient postClient, TapeServiceNewClient tapeClient, FriendshipServiceClient friendshipClient, CommentServiceNewClient commentClient, SubscriptionServiceNewClient subClient)
        {
            Tape tape = (Tape)entity;
            List<PostInfo> posts = new List<PostInfo>();
            IEnumerable<Post> tapePosts = postClient.GetPosts().Where(p => p.TapeID == tape.ID);
            foreach (Post post in tapePosts) posts.Add(CreatePostInfo(post, userClient, postClient, tapeClient, commentClient, friendshipClient,subClient));
            return new TapeInfo
            {
                ID = tape.ID,
                Posts = posts
            };
        }
    }
}