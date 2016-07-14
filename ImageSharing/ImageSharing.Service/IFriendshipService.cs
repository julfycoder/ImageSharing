using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.DAL.EntityNew;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFriendshipService" in both code and config file together.
    [ServiceContract]
    public interface IFriendshipService
    {
        [OperationContract]
        void AddFriendship(Friendship friendship);

        [OperationContract]
        void RemoveFriendship(int id);

        [OperationContract]
        Friendship GetFriendship(int id);

        [OperationContract]
        IEnumerable<Friendship> GetFriendships();
    }
}
