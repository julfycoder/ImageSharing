using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.UserServiceNew;
using ImageSharing.TapeServiceNew;
using ImageSharing.PostServiceNew;
using ImageSharing.SubscriptionServiceNew;
using ImageSharing.CommentServiceNew;
using ImageSharing.FriendshipRequestServiceNew;
using ImageSharing.FriendshipService;
using ImageSharing.DAL.EntityNew;
using ImageSharing.Models;
using ImageSharing.Models.EntityInfo;
using ImageSharing.Models.InfoCreatorNew;

namespace ImageSharing.Models
{
    public class WCFAccess:IAccessible
    {
        UserServiceNewClient userClient = new UserServiceNewClient();
        TapeServiceNewClient tapeClient = new TapeServiceNewClient();
        PostServiceNewClient postClient = new PostServiceNewClient();
        SubscriptionServiceNewClient subClient = new SubscriptionServiceNewClient();
        CommentServiceNewClient commentClient = new CommentServiceNewClient();
        FriendshipServiceClient friendshipClient = new FriendshipServiceClient();
        FriendshipRequestServiceNewClient requestClient = new FriendshipRequestServiceNewClient();
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