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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        UserHelper helper = new UserHelper(new Repository());
        public void AddUser(UserAccount user)
        {
            helper.AddUser(user);
        }

        public UserAccount GetUser(int id)
        {
            return helper.GetUser(id);
        }

        public IEnumerable<UserAccount> GetUsers()
        {
            return helper.GetUsers();
        }

        public void ChangeName(int id, string name)
        {
            helper.ChangeName(id, name);
        }

        public void ChangeSurname(int id, string surname)
        {
            helper.ChangeSurname(id, surname);
        }

        public void ChangeEmail(int id, string email)
        {
            helper.ChangeEmail(id, email);
        }

        public void ChangePassword(int id, string password)
        {
            helper.ChangePassword(id, password);
        }

        public void ChangeAvatarPath(int id, string avatarPath)
        {
            helper.ChangeAvatarPath(id, avatarPath);
        }

        public void AddFriend(int id, int friendId)
        {
            helper.AddFriend(id, friendId);
        }

        public void RemoveFriend(int id, int friendId)
        {
            helper.RemoveFriend(id, friendId);
        }

        public void AddSubscription(int id, int subscriptionId)
        {
            helper.AddSubscription(id, subscriptionId);
        }

        public void RemoveSubscription(int id, int subscriptionId)
        {
            helper.RemoveSubscription(id, subscriptionId);
        }

        public void RemoveUser(int id)
        {
            helper.RemoveUser(id);
        }

        public void ActivateAccount(int id)
        {
            helper.ActivateAccount(id);
        }

        public IEnumerable<UserAccount> GetFriends(int id)
        {
            return helper.GetFriends(id);
        }

        public IEnumerable<Subscription> GetSubscriptions(int id)
        {
            return helper.GetSubscriptions(id);
        }

        public void SetTapeId(int id, int tapeId)
        {
            helper.SetTapeId(id, tapeId);
        }


        public void AddRequest(int id, int requestId)
        {
            helper.AddRequest(id, requestId);
        }

        public void RemoveRequest(int id, int requestId)
        {
            helper.RemoveRequest(id, requestId);
        }

        public IEnumerable<FriendshipRequest> GetRequests(int id)
        {
            return helper.GetRequests(id);
        }
    }
}
