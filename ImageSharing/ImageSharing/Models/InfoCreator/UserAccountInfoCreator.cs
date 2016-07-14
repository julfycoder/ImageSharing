using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.Models.EntityInfo;
using ImageSharing.DAL.Entity;
using ImageSharing.UserService;
using ImageSharing.PostService;
using ImageSharing.TapeService;
using System.IO;

namespace ImageSharing.Models.InfoCreator
{
    public class UserAccountInfoCreator : EntityInfoCreator
    {
        SubscriptionInfoCreator subCreator = new SubscriptionInfoCreator();
        TapeInfoCreator tapeCreator = new TapeInfoCreator();
        FriendInfoCreator friendCreator = new FriendInfoCreator();
        FriendInfo CreateFriendInfo(UserAccount friend, UserServiceClient userClient, PostServiceClient postClient, TapeServiceClient tapeClient)
        {
            return (FriendInfo)friendCreator.Create(friend, userClient, postClient, tapeClient);
        }
        TapeInfo CreateTapeInfo(Tape tape, UserServiceClient userClient, PostServiceClient postClient, TapeServiceClient tapeClient)
        {
            return (TapeInfo)tapeCreator.Create(tape, userClient, postClient, tapeClient);
        }
        SubscriptionInfo CreateSubscriptionInfo(Subscription subscription, UserServiceClient userClient, PostServiceClient postClient, TapeServiceClient tapeClient)
        {
            return (SubscriptionInfo)subCreator.Create(subscription, userClient, postClient, tapeClient);
        }

        public override EntityInfoBase Create(Entity entity, UserServiceClient userClient, PostServiceClient postClient, TapeServiceClient tapeClient)
        {
            UserAccount user = (UserAccount)entity;

            List<FriendInfo> friends = new List<FriendInfo>();
            IEnumerable<UserAccount> userFriends = userClient.GetFriends(user.ID);
            foreach (UserAccount friend in userFriends) friends.Add(CreateFriendInfo(friend, userClient, postClient, tapeClient));

            List<SubscriptionInfo> subs = new List<SubscriptionInfo>();
            IEnumerable<Subscription> userSubs = userClient.GetSubscriptions(user.ID);
            foreach (Subscription sub in userSubs) subs.Add(CreateSubscriptionInfo(sub, userClient, postClient, tapeClient));

            Tape userTape = tapeClient.GetTape(user.TapeID);
            return new UserAccountInfo
            {
                ID = user.ID,
                Name = user.Name,
                Surname = user.Surname,
                AvatarPath = user.AvatarPath,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                Friends = friends,
                Subscriptions = subs,
                Tape = CreateTapeInfo(userTape, userClient, postClient, tapeClient)
            };
        }
    }
}