using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.DAL.Entity;

namespace ImageSharing.DAL
{
    public class Repository : IRepository
    {
        SocNetContext context = new SocNetContext();

        public IEnumerable<UserAccount> Users
        {
            get { return context.Users; }
        }

        public IEnumerable<Comment> Comments
        {
            get { return context.Comments; }
        }

        public IEnumerable<Tape> Tapes
        {
            get { return context.Tapes; }
        }

        public IEnumerable<Post> Posts
        {
            get { return context.Posts; }
        }

        public IEnumerable<FriendshipRequest> Requests
        {
            get { return context.FriendshipRequests; }
        }

        public IEnumerable<Subscription> Subscriptions
        {
            get { return context.Subscriptions; }
        }

        public void AddEntity<T>(T entity) where T : Entity.Entity
        {
            context.Set<T>().Add(entity);
        }

        public void RemoveEntity<T>(T entity) where T : Entity.Entity
        {
            context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }


        
    }
}
