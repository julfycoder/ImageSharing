using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.Models.EntityInfo;
using ImageSharing.DAL.Entity;
using ImageSharing.UserService;
using ImageSharing.PostService;
using ImageSharing.TapeService;

namespace ImageSharing.Models.InfoCreator
{
    public class TapeInfoCreator : EntityInfoCreator
    {
        PostInfoCreator postInfoCreator = new PostInfoCreator();
        PostInfo CreatePostInfo(Post post, UserServiceClient userClient, PostServiceClient postClient, TapeServiceClient tapeClient)
        {
            return (PostInfo)postInfoCreator.Create(post, userClient, postClient, tapeClient);
        }

        public override EntityInfoBase Create(Entity entity, UserServiceClient userClient, PostServiceClient postClient, TapeServiceClient tapeClient)
        {
            Tape tape = (Tape)entity;
            List<PostInfo> posts = new List<PostInfo>();
            IEnumerable<Post> tapePosts = tapeClient.GetPosts(tape.ID);
            foreach (Post post in tapePosts) posts.Add(CreatePostInfo(post, userClient, postClient, tapeClient));
            return new TapeInfo
            {
                ID = tape.ID,
                Posts = posts
            };
        }
    }
}