using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.DAL.EntityNew;

namespace ImageSharing.DAL
{
    public interface IImageSharingRepository
    {
        IEnumerable<UserAccount> Users { get; }
        IEnumerable<Comment> Comments { get; }
        IEnumerable<Tape> Tapes { get; }
        IEnumerable<Post> Posts { get; }
        IEnumerable<Subscription> Subscriptions { get; }
        IEnumerable<FriendshipRequest> Requests { get; }
        IEnumerable<Friendship> Friendships { get; }
        void AddEntity<T>(T entity) where T : EntityNew.Entity;
        void RemoveEntity<T>(T entity) where T : EntityNew.Entity;
        void SaveChanges();
    }
}
