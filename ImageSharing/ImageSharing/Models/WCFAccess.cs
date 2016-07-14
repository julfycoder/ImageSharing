using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.DAL.Entity;
using ImageSharing.UserService;
using ImageSharing.TapeService;
using ImageSharing.PostService;
using ImageSharing.SubscriptionService;
using ImageSharing.CommentService;
using ImageSharing.FriendshipRequestService;
using ImageSharing.FriendshipService;
using ImageSharing.Models;
using ImageSharing.Models.EntityInfo;
using ImageSharing.Models.InfoCreator;

namespace ImageSharing.Models
{
    public class WCFAccess:IAccessible
    {
        UserServiceClient userClient = new UserServiceClient();
        TapeServiceClient tapeClient = new TapeServiceClient();
        PostServiceClient postClient = new PostServiceClient();
        SubscriptionServiceClient subClient = new SubscriptionServiceClient();
        CommentServiceClient commentClient = new CommentServiceClient();
        FriendshipServiceClient friendshipClient = new FriendshipServiceClient();
        FriendshipRequestServiceClient requestClient = new FriendshipRequestServiceClient();
        public T GetEntity<T>(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetEntities<T>()
        {
            throw new NotImplementedException();
        }

        public void AddEntity<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveEntity<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}