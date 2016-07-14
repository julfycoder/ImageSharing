using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.DAL.Entity;
using ImageSharing.DAL;

namespace ImageSharing.Business
{
    [Serializable]
    public class UserHelper
    {
        IRepository repository;
        public UserHelper(IRepository repository)
        {
            this.repository = repository;
        }
        public void AddUser(UserAccount user)
        {
            repository.AddEntity(user);
            repository.SaveChanges();
        }
        public void RemoveUser(int id)
        {
            repository.RemoveEntity(GetUser(id));
            repository.SaveChanges();
        }
        public UserAccount GetUser(int id)
        {
            return repository.Users.ToList().First(u => u.ID == id);
        }
        public UserAccount GetUser(string email, string password)
        {
            return repository.Users.ToList().First(u => u.Email == email && u.Password == password);
        }
        public IEnumerable<UserAccount> GetUsers()
        {
            return repository.Users;
        }
        public void ChangeName(int id, string name)
        {
            UserAccount user = GetUser(id);
            user.Name = name;
            repository.SaveChanges();
        }
        public void ChangeSurname(int id, string surname)
        {
            UserAccount user = GetUser(id);
            user.Surname = surname;
            repository.SaveChanges();
        }
        public void ChangeEmail(int id, string email)
        {
            UserAccount user = GetUser(id);
            user.Email = email;
            repository.SaveChanges();
        }
        public void ChangePassword(int id, string password)
        {
            UserAccount user = GetUser(id);
            user.Password = password;
            repository.SaveChanges();
        }
        public void ChangeAvatarPath(int id, string avatarPath)
        {
            UserAccount user = GetUser(id);
            user.AvatarPath = avatarPath;
            repository.SaveChanges();
        }
        public void SetTapeId(int id, int tapeId)
        {
            UserAccount user = GetUser(id);
            user.TapeID = tapeId;
            repository.SaveChanges();
        }
        public void AddFriend(int id, int friendId)
        {
            UserAccount user = GetUser(id);
            if (user.IDsFriends == null) user.IDsFriends = "";
            if (user.IDsFriends.Count() == 0) user.IDsFriends += friendId.ToString();
            else user.IDsFriends += "," + friendId.ToString();
            repository.SaveChanges();
        }
        public void RemoveFriend(int id, int friendId)
        {
            UserAccount user = GetUser(id);
            string[] IDsFriends = user.IDsFriends.Split(',');
            user.IDsFriends = "";
            foreach (string friend in IDsFriends)
            {
                if (friend != friendId.ToString())
                {
                    if (user.IDsFriends.Count() == 0)
                    {
                        user.IDsFriends += friend;
                    }
                    else user.IDsFriends += "," + friend;
                }
            }
            repository.SaveChanges();
        }
        public void AddSubscription(int id, int friendId)
        {
            UserAccount user = GetUser(id);
            if (user.IDsSubscriptions == null) user.IDsSubscriptions = "";
            if (user.IDsSubscriptions.Count() == 0) user.IDsSubscriptions += friendId.ToString();
            else user.IDsSubscriptions += "," + friendId.ToString();
            repository.SaveChanges();
        }
        public void RemoveSubscription(int id, int friendId)
        {
            UserAccount user = GetUser(id);
            string[] IDsSubscriptions = user.IDsSubscriptions.Split(',');
            user.IDsSubscriptions = "";
            foreach (string friend in IDsSubscriptions)
            {
                if (friend != friendId.ToString())
                {
                    if (user.IDsSubscriptions.Count() == 0)
                    {
                        user.IDsSubscriptions += friend;
                    }
                    else user.IDsSubscriptions += "," + friend;
                }
            }
            repository.SaveChanges();
        }
        public void ActivateAccount(int id)
        {
            UserAccount user = GetUser(id);
            user.IsActivated = true;
            repository.SaveChanges();
        }
        public IEnumerable<UserAccount> GetFriends(int id)
        {
            List<string> IDs = new List<string>();
            if (GetUser(id).IDsFriends != null && GetUser(id).IDsFriends != "") IDs.AddRange(GetUser(id).IDsFriends.Split(','));
            List<UserAccount> friends = new List<UserAccount>();
            foreach (string userId in IDs)
            {
                friends.Add(GetUsers().ToList().First(u => u.ID == int.Parse(userId)));
            }
            return friends;
        }
        public IEnumerable<Subscription> GetSubscriptions(int id)
        {
            List<string> IDs = new List<string>();
            UserAccount user = GetUser(id);
            if (user.IDsSubscriptions != null && user.IDsSubscriptions != "") IDs.AddRange(GetUser(id).IDsSubscriptions.Split(','));
            List<Subscription> subs = new List<Subscription>();
            foreach (string subId in IDs)
            {
                subs.Add(repository.Subscriptions.ToList().First(s => s.ID == int.Parse(subId)));
            }
            return subs;
        }
        public void AddRequest(int id, int requestId)
        {
            UserAccount user = GetUser(id);
            if (user.IDsRequests == null) user.IDsRequests = "";
            if (user.IDsRequests.Count() == 0) user.IDsRequests += requestId.ToString();
            else user.IDsRequests += "," + requestId.ToString();
            repository.SaveChanges();
        }
        public void RemoveRequest(int id, int requestId)
        {
            UserAccount user = GetUser(id);
            string[] IDsRequests = user.IDsRequests.Split(',');
            user.IDsRequests = "";
            foreach (string request in IDsRequests)
            {
                if (request != requestId.ToString())
                {
                    if (user.IDsRequests.Count() == 0)
                    {
                        user.IDsRequests += request;
                    }
                    else user.IDsRequests += "," + request;
                }
            }
            repository.SaveChanges();
        }
        public IEnumerable<FriendshipRequest> GetRequests(int id)
        {
            List<string> IDs = new List<string>();
            UserAccount user = GetUser(id);
            if (user.IDsRequests != null && user.IDsRequests != "") IDs.AddRange(user.IDsRequests.Split(','));
            List<FriendshipRequest> requests = new List<FriendshipRequest>();
            foreach (string requestId in IDs)
            {
                requests.Add(repository.Requests.ToList().First(r => r.ID == int.Parse(requestId)));
            }
            return requests;
        }
    }
}
