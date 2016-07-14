using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.DAL.Entity;

namespace ImageSharing.DAL
{
    public interface IRepository
    {
        IEnumerable<UserAccount> Users { get; }
        IEnumerable<Comment> Comments { get; }
        IEnumerable<Tape> Tapes { get; }
        IEnumerable<Post> Posts { get; }
        IEnumerable<Subscription> Subscriptions { get; }
        IEnumerable<FriendshipRequest> Requests { get; }
        void AddEntity<T>(T entity) where T : Entity.Entity;
        void RemoveEntity<T>(T entity) where T : Entity.Entity;
        void SaveChanges();
    }
}
