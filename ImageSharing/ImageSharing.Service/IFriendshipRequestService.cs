using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.DAL.Entity;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFriendshipRequestServiceNew" in both code and config file together.
    [ServiceContract]
    public interface IFriendshipRequestService
    {
        [OperationContract]
        FriendshipRequest GetRequest(int id);

        [OperationContract]
        IEnumerable<FriendshipRequest> GetRequests();

        [OperationContract]
        void AddRequest(FriendshipRequest request);

        [OperationContract]
        void RemoveRequest(int id);
    }
}
