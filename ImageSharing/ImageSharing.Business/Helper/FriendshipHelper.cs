using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.DAL;
using ImageSharing.DAL.Entity;

namespace ImageSharing.Business.Helper
{
    public class FriendshipHelper
    {
        IImageSharingRepository repository;
        public FriendshipHelper(IImageSharingRepository repository)
        {
            this.repository = repository;
        }
        public void AddFriendship(Friendship friendship)
        {
            repository.AddEntity(friendship);
            repository.SaveChanges();
        }
        public void RemoveFriendship(int id)
        {
            repository.RemoveEntity(GetFriendship(id));
            repository.SaveChanges();
        }
        public Friendship GetFriendship(int id)
        {
            return repository.Friendships.First(f => f.ID == id);
        }
        public IEnumerable<Friendship> GetFriendships()
        {
            return repository.Friendships;
        }
    }
}
