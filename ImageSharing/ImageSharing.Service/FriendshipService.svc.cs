using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.DAL;
using ImageSharing.DAL.Entity;
using ImageSharing.Business.Helper;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FriendshipService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FriendshipService.svc or FriendshipService.svc.cs at the Solution Explorer and start debugging.
    public class FriendshipService : IFriendshipService
    {
        FriendshipHelper helper = new FriendshipHelper(new ImageSharingRepository());
        public void AddFriendship(Friendship friendship)
        {
            helper.AddFriendship(friendship);
        }

        public void RemoveFriendship(int id)
        {
            helper.RemoveFriendship(id);
        }

        public Friendship GetFriendship(int id)
        {
            return helper.GetFriendship(id);
        }

        public IEnumerable<Friendship> GetFriendships()
        {
            return helper.GetFriendships();
        }
    }
}
