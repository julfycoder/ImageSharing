using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.Business;
using ImageSharing.DAL;
using ImageSharing.DAL.Entity;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        void AddUser(UserAccount user);

        [OperationContract]
        UserAccount GetUser(int id);

        [OperationContract]
        IEnumerable<UserAccount> GetUsers();

        [OperationContract]
        void ChangeName(int id,string name);

        [OperationContract]
        void ChangeSurname(int id,string surname);

        [OperationContract]
        void ChangeEmail(int id,string email);

        [OperationContract]
        void ChangePassword(int id,string password);

        [OperationContract]
        void ChangeAvatarPath(int id,string avatarPath);

        [OperationContract]
        void AddFriend(int id,int friendId);

        [OperationContract]
        void RemoveFriend(int id,int friendId);

        [OperationContract]
        void AddSubscription(int id,int subscriptionId);

        [OperationContract]
        void RemoveSubscription(int id,int subscriptionId);

        [OperationContract]
        void RemoveUser(int id);

        [OperationContract]
        void ActivateAccount(int id);

        [OperationContract]
        IEnumerable<UserAccount> GetFriends(int id);

        [OperationContract]
        IEnumerable<Subscription> GetSubscriptions(int id);

        [OperationContract]
        void SetTapeId(int id, int tapeId);

        [OperationContract]
        void AddRequest(int id, int requestId);
        
        [OperationContract]
        void RemoveRequest(int id, int requestId);

        [OperationContract]
        IEnumerable<FriendshipRequest> GetRequests(int id);
        
    }
}
