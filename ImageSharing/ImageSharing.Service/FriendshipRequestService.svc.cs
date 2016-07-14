using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.DAL;
using ImageSharing.DAL.Entity;
using ImageSharing.Business;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FriendshipRequestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FriendshipRequestService.svc or FriendshipRequestService.svc.cs at the Solution Explorer and start debugging.
    public class FriendshipRequestService : IFriendshipRequestService
    {
        FriendshipRequestHelper helper = new FriendshipRequestHelper(new Repository());
        public FriendshipRequest GetRequest(int id)
        {
            return helper.GetRequest(id);
        }

        public IEnumerable<FriendshipRequest> GetRequests()
        {
            return helper.GetRequests();
        }

        public void AddRequest(FriendshipRequest request)
        {
            helper.AddRequest(request);
        }

        public void RemoveRequest(int id)
        {
            helper.RemoveRequest(id);
        }
    }
}
