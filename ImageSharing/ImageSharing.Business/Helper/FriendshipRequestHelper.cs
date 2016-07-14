using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.DAL;
using ImageSharing.DAL.EntityNew;

namespace ImageSharing.Business.Helper
{
    public class FriendshipRequestHelper
    {
        IImageSharingRepository repository;
        public FriendshipRequestHelper(IImageSharingRepository repository)
        {
            this.repository=repository;
        }
        public FriendshipRequest GetRequest(int id)
        {
            return repository.Requests.First(r => r.ID == id);
        }
        public IEnumerable<FriendshipRequest> GetRequests()
        {
            return repository.Requests;
        }
        public void AddRequest(FriendshipRequest request)
        {
            repository.AddEntity(request);
            repository.SaveChanges();
        }
        public void RemoveRequest(int id)
        {
            repository.RemoveEntity(GetRequest(id));
            repository.SaveChanges();
        }
    }
}
