using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSharing.Models.EntityInfo;
using ImageSharing.DAL.Entity;
using ImageSharing.UserService;
using ImageSharing.TapeService;
using ImageSharing.PostService;
using ImageSharing.SubscriptionService;
using ImageSharing.CommentService;
using ImageSharing.FriendshipRequestService;
using ImageSharing.FriendshipService;
using System.IO;

namespace ImageSharing.Models.InfoCreator
{
    public class UserAccountInfoCreator : EntityInfoCreator
    {
        SubscriptionInfoCreator subCreator = new SubscriptionInfoCreator();
        TapeInfoCreator tapeCreator = new TapeInfoCreator();
        FriendInfoCreator friendCreator = new FriendInfoCreator();

        FriendInfo CreateFriendInfo(UserAccount friend,
            UserServiceClient userClient,
            PostServiceClient postClient,
            TapeServiceClient tapeClient,
            FriendshipServiceClient friendshipClient,
            CommentServiceClient commentClient,
            SubscriptionServiceClient subClient)
        {
            return (FriendInfo)friendCreator.Create(friend, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient);
        }
        TapeInfo CreateTapeInfo(Tape tape,
            UserServiceClient userClient,
            PostServiceClient postClient,
            TapeServiceClient tapeClient,
            FriendshipServiceClient friendshipClient,
            CommentServiceClient commentClient,
            SubscriptionServiceClient subClient)
        {
            return (TapeInfo)tapeCreator.Create(tape, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient);
        }
        SubscriptionInfo CreateSubscriptionInfo(Subscription subscription,
            UserServiceClient userClient,
            PostServiceClient postClient,
            TapeServiceClient tapeClient,
            FriendshipServiceClient friendshipClient,
            CommentServiceClient commentClient,
            SubscriptionServiceClient subClient)
        {
            return (SubscriptionInfo)subCreator.Create(subscription, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient);
        }

        public override EntityInfoBase Create(Entity entity,
            UserServiceClient userClient,
            PostServiceClient postClient,
            TapeServiceClient tapeClient,
            FriendshipServiceClient friendshipClient,
            CommentServiceClient commentClient,
            SubscriptionServiceClient subClient)
        {
            UserAccount user = (UserAccount)entity;

            List<FriendInfo> friends = new List<FriendInfo>();
            List<UserAccount> userFriends = new List<UserAccount>();
            IEnumerable<Friendship> friendships = friendshipClient.GetFriendships().Where(f => f.User1ID == user.ID || f.User2ID == user.ID);
            foreach (Friendship f in friendships)
            {
                if (f.User1ID == user.ID) userFriends.Add(userClient.GetUser(f.User2ID));
                if (f.User2ID == user.ID) userFriends.Add(userClient.GetUser(f.User1ID));
            }

            foreach (UserAccount friend in userFriends) friends.Add(CreateFriendInfo(friend, userClient, postClient, tapeClient,  friendshipClient,commentClient, subClient));

            List<SubscriptionInfo> subs = new List<SubscriptionInfo>();
            IEnumerable<Subscription> userSubs = subClient.GetSubscriptions().Where(s => s.FollowerID == user.ID);
            foreach (Subscription sub in userSubs) subs.Add(CreateSubscriptionInfo(sub, userClient, postClient, tapeClient,  friendshipClient,commentClient, subClient));

            Tape userTape = tapeClient.GetTapes().First(t => t.UserID == user.ID);
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
                Tape = CreateTapeInfo(userTape, userClient, postClient, tapeClient,  friendshipClient,commentClient, subClient)
            };
        }
    }
}