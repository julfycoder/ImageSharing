using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageSharing.Models;
using ImageSharing.Models.EntityInfo;
using ImageSharing.DAL.Entity;
using ImageSharing.UserService;
using ImageSharing.TapeService;
using ImageSharing.PostService;
using ImageSharing.SubscriptionService;
using ImageSharing.CommentService;
using ImageSharing.FriendshipRequestService;
using ImageSharing.FriendshipService;
using ImageSharing.Models.InfoCreator;
using ImageSharing.Security;
using System.Threading;
using System.Globalization;
using ImageSharing.Culture;

namespace ImageSharing.Areas.User.Controllers
{
    public class UserHomeController : Controller
    {
        //
        // GET: /User/UserHome/
        UserServiceClient userClient = new UserServiceClient();
        TapeServiceClient tapeClient = new TapeServiceClient();
        PostServiceClient postClient = new PostServiceClient();
        SubscriptionServiceClient subClient = new SubscriptionServiceClient();
        CommentServiceClient commentClient = new CommentServiceClient();
        FriendshipServiceClient friendshipClient = new FriendshipServiceClient();
        FriendshipRequestServiceClient requestClient = new FriendshipRequestServiceClient();

        #region Actions
        public ActionResult Home()
        {
            int ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);
            UserAccount user = userClient.GetUser(int.Parse(HttpContext.Request.Cookies["ID"].Value));
            UserAccountInfo userInfo = (UserAccountInfo)new UserAccountInfoCreator().Create(user, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient);
            foreach (FriendInfo friend in userInfo.Friends)     //Adding friends posts
            {
                if (subClient.GetSubscriptions().Any(s => s.FollowerID == ID && s.UserID == friend.ID))
                {
                    Subscription sub = subClient.GetSubscriptions().First(s => s.FollowerID == ID && s.UserID == friend.ID);
                    IEnumerable<Post>posts=postClient.GetPosts().Where(p=>p.TapeID==tapeClient.GetTapes().First(t=>t.UserID==friend.ID).ID);
                    foreach (Post post in posts) if(post.DateTime>sub.DateTime)userInfo.Tape.Posts.Add((PostInfo)new PostInfoCreator().Create(post, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient));
                }
            }

            for (int i = 0; i < userInfo.Tape.Posts.Count(); i++)//Sort
            {
                for (int j = userInfo.Tape.Posts.Count() - 1; j > 0; j--)
                {
                    if (i < j)
                    {
                        PostInfo iPost = userInfo.Tape.Posts[i];
                        PostInfo jPost = userInfo.Tape.Posts[j];
                        if (iPost.DateTime < jPost.DateTime)
                        {
                            PostInfo temp = iPost;
                            userInfo.Tape.Posts[i] = jPost;
                            userInfo.Tape.Posts[j] = temp;
                        }
                    }
                }
            }
            return View(userInfo);
        }
        public ActionResult FriendsPage()
        {
            int ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);

            List<FriendInfo> friends = new List<FriendInfo>();
            List<UserAccount> userFriends = new List<UserAccount>();
            IEnumerable<Friendship> friendships = friendshipClient.GetFriendships().Where(f => f.User1ID == ID || f.User2ID == ID);
            foreach (Friendship f in friendships)
            {
                if (f.User1ID == ID) userFriends.Add(userClient.GetUser(f.User2ID));
                if (f.User2ID == ID) userFriends.Add(userClient.GetUser(f.User1ID));
            }
            foreach (UserAccount friend in userFriends) friends.Add((FriendInfo)new FriendInfoCreator().Create(friend, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient));
            return View(friends);
        }
        public ActionResult AccountPage()
        {
            UserAccountInfo userInfo = (UserAccountInfo)new UserAccountInfoCreator().Create(userClient.GetUser(int.Parse(HttpContext.Request.Cookies["ID"].Value)), userClient, postClient, tapeClient, friendshipClient, commentClient, subClient);
            ChangeAccountModel accountModel = new ChangeAccountModel 
            {
                Name=userInfo.Name,
                Surname=userInfo.Surname,
                Email=userInfo.Email,
                Avatar=userInfo.AvatarName
            };
            accountModel.Password = "";
            return View(accountModel);
        }
        [HttpPost]
        public ActionResult ChangeAccountInfo(ChangeAccountModel accountInfo, HttpPostedFileBase Avatar)
        {
            UserAccountInfo userInfo = (UserAccountInfo)new UserAccountInfoCreator().Create(userClient.GetUser(int.Parse(HttpContext.Request.Cookies["ID"].Value)), userClient, postClient, tapeClient, friendshipClient, commentClient, subClient);
            if (userInfo.Name != accountInfo.Name && accountInfo.Name != "" && accountInfo.Name != null) userClient.ChangeName(userInfo.ID, accountInfo.Name);
            if (userInfo.Surname != accountInfo.Surname && accountInfo.Surname != "" && accountInfo.Surname != null) userClient.ChangeSurname(userInfo.ID, accountInfo.Surname);
            if (userInfo.Email != accountInfo.Email && accountInfo.Email != "" && accountInfo.Email != null) userClient.ChangeEmail(userInfo.ID, accountInfo.Email);
            if (userInfo.Password != accountInfo.Password && accountInfo.Password != "" && accountInfo.Password != null) userClient.ChangePassword(userInfo.ID, Scrambler.GetMD5Hash(accountInfo.Password));
            if (Avatar != null && userInfo.AvatarName != Avatar.FileName && Avatar.ContentType.ToLower().Split('/')[0] == "image")
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"Content\AvatarImages\";
                string fileName = Path.GetFileName(Avatar.FileName);
                string rootPath = Path.Combine(path, fileName);
                if (fileName != null) Avatar.SaveAs(rootPath);

                userClient.ChangeAvatarPath(userInfo.ID, Avatar.FileName);
            }

            return RedirectToAction("AccountPage");
        }
        [HttpPost]
        public ActionResult UploadPost(HttpPostedFileBase upload, string Description)
        {
            if (upload.ContentType.ToLower().Split('/')[0] == "image")
            {
                int ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);

                if (upload == null) return RedirectToAction("Home");
                string path = AppDomain.CurrentDomain.BaseDirectory + @"Content\UploadedImages\";
                string fileName = Path.GetFileName(upload.FileName);
                string rootPath = Path.Combine(path, fileName);
                if (fileName != null) upload.SaveAs(rootPath);

                IEnumerable<Post> posts = postClient.GetPosts();

                Post post = new Post
                {
                    AuthorID = int.Parse(HttpContext.Request.Cookies["ID"].Value),
                    DateTime = DateTime.Now,
                    ImagePath = fileName,
                    Description = Description,
                    TapeID = tapeClient.GetTapes().First(t => t.UserID == ID).ID
                };
                postClient.AddPost(post);
            }
            return RedirectToAction("Home");
        }
        public ActionResult Logout()
        {
            HttpContext.Response.Cookies["Role"].Value = "";
            HttpContext.Response.Cookies["ID"].Value = "";
            return RedirectToAction("LoginPage", "Home", new { area = "" });
        }
        public ActionResult MakeFriend(int id)
        {
            int ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);
            if (!requestClient.GetRequests().Any(r => r.AskerID == id && r.DestinationID == ID))
            {
                IEnumerable<FriendshipRequest> requests = requestClient.GetRequests();
                FriendshipRequest request = new FriendshipRequest
                {
                    AskerID = ID,
                    DestinationID = id
                };
                requestClient.AddRequest(request);
            }

            if (requestClient.GetRequests().Any(r => r.AskerID == id && r.DestinationID == ID)) //При добавлении в друзья проверяем были ли от данного пользователя запросы и удаляем таковые
            {
                IEnumerable<FriendshipRequest> myRequests = requestClient.GetRequests().Where(r => r.AskerID == id && r.DestinationID == ID);
                foreach (FriendshipRequest request in myRequests)
                {
                    requestClient.RemoveRequest(request.ID);
                }
                friendshipClient.AddFriendship(new Friendship { User1ID = ID, User2ID = id });
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult RemoveRequest(int id)
        {
            int ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);
            UserAccount currentUser = userClient.GetUser(ID);
            IEnumerable<FriendshipRequest> requests = requestClient.GetRequests().Where(r => r.AskerID == id);
            foreach (FriendshipRequest request in requests)
            {
                requestClient.RemoveRequest(request.ID);
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult RequestsPage()
        {
            int ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);
            IEnumerable<FriendshipRequest> requests = requestClient.GetRequests().Where(r => r.DestinationID == ID);

            List<UserAccount> users = new List<UserAccount>();
            List<UserAccountInfo> userInfos = new List<UserAccountInfo>();
            UserAccountInfoCreator userCreator = new UserAccountInfoCreator();
            foreach (FriendshipRequest request in requests) users.Add(userClient.GetUsers().First(u => u.ID == request.AskerID));

            foreach (UserAccount user in users) userInfos.Add((UserAccountInfo)userCreator.Create(user, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient));

            return View(userInfos);
        }

        public ActionResult RemoveFriend(int id)
        {
            int ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);
            if (requestClient.GetRequests().Any(r => (r.DestinationID == ID && r.AskerID == id) || (r.DestinationID == id && r.AskerID == ID)))
                requestClient.RemoveRequest(requestClient.GetRequests().First(r => (r.DestinationID == ID && r.AskerID == id) || (r.DestinationID == id && r.AskerID == ID)).ID);

            if (subClient.GetSubscriptions().Any(s => s.FollowerID == ID && s.UserID == id)) subClient.RemoveSubscription(subClient.GetSubscriptions().First(s => s.FollowerID == ID && s.UserID == id).ID);//my
            if (subClient.GetSubscriptions().Any(s => s.FollowerID == id && s.UserID == ID)) subClient.RemoveSubscription(subClient.GetSubscriptions().First(s => s.FollowerID == id && s.UserID == ID).ID);//his

            friendshipClient.RemoveFriendship(friendshipClient.GetFriendships().First(f => (f.User1ID == ID && f.User2ID == id) || f.User1ID == id && f.User2ID == ID).ID);

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult SubscriptionsPage()
        {
            int ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);

            SubscriptionInfoCreator subCreator = new SubscriptionInfoCreator();
            List<SubscriptionInfo> subInfos = new List<SubscriptionInfo>();
            IEnumerable<Subscription> subs = subClient.GetSubscriptions().Where(s => s.FollowerID == ID);
            foreach (Subscription sub in subs) subInfos.Add((SubscriptionInfo)subCreator.Create(sub, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient));
            return View(subInfos);
        }
        public ActionResult Follow(int id)
        {
            int ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);
            IEnumerable<Subscription> subs = subClient.GetSubscriptions();
            Subscription sub = new Subscription
            {
                FollowerID = ID,
                UserID = id,
                DateTime = DateTime.Now
            };
            subClient.AddSubscription(sub);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult Unfollow(int id)
        {
            int ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);
            if (subClient.GetSubscriptions().Any(s => s.FollowerID == ID && s.UserID == id)) subClient.RemoveSubscription(subClient.GetSubscriptions().First(s => s.FollowerID == ID && s.UserID == id).ID);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult SearchFriends(string searchString)
        {
            int ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);
            FriendInfoCreator friendCreator = new FriendInfoCreator();

            List<FriendInfo> friendInfos = new List<FriendInfo>();
            List<UserAccount> userFriends = new List<UserAccount>();
            IEnumerable<Friendship> friendships = friendshipClient.GetFriendships().Where(f => f.User1ID == ID || f.User2ID == ID);
            foreach (Friendship f in friendships)
            {
                if (f.User1ID == ID) userFriends.Add(userClient.GetUser(f.User2ID));
                if (f.User2ID == ID) userFriends.Add(userClient.GetUser(f.User1ID));
            }
            IEnumerable<UserAccount> friends = userFriends.Where(f => f.Name.ToLower().Contains(searchString.ToLower()) || f.Surname.ToLower().Contains(searchString.ToLower()));
            foreach (UserAccount friend in friends) friendInfos.Add((FriendInfo)friendCreator.Create(friend, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient));
            return View("FriendsPage", friendInfos);
        }
        public ActionResult SearchSubscriptions(string searchString)
        {
            int ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);
            SubscriptionInfoCreator subCreator = new SubscriptionInfoCreator();
            List<SubscriptionInfo> subInfos = new List<SubscriptionInfo>();
            IEnumerable<Subscription> subs = subClient.GetSubscriptions().Where(s => s.FollowerID == ID);
            foreach (Subscription sub in subs) subInfos.Add((SubscriptionInfo)subCreator.Create(sub, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient));
            return View("SubscriptionsPage", subInfos.Where(s => s.UserName.ToLower().Contains(searchString.ToLower()) || s.Surname.ToLower().Contains(searchString.ToLower())).ToList());
        }
        public ActionResult RemovePost(int id)
        {
            int ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);
            IEnumerable<Comment> comments = commentClient.GetComments().Where(c => c.PostID == id);
            foreach (Comment comment in comments)
            {
                commentClient.RemoveComment(comment.ID);
            }
            postClient.RemovePost(id);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult Comments(CommentationModel commentation, int id)
        {
            int ID = 0;
            if (HttpContext.Request.Cookies != null && HttpContext.Request.Cookies["ID"]!=null&&HttpContext.Request.Cookies["ID"].Value != "") ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);

            if (commentation.Comment != null && commentation.Comment.Count() > 0 && commentation.Comment.Split(' ').Count() > 0)
            {
                Post post = postClient.GetPost(commentation.PostID);

                UserAccount currentUser = userClient.GetUser(ID);
                commentClient.AddComment(new Comment
                {
                    Text = "'" + commentation.Comment + "' - " + currentUser.Name + " " + currentUser.Surname + " " + DateTime.Now,
                    PostID = id
                });
            }

            IEnumerable<Comment> comments = commentClient.GetComments().Where(c => c.PostID == id);
            List<CommentInfo> commentInfos = new List<CommentInfo>();
            CommentInfoCreator commentCreator = new CommentInfoCreator();
            foreach (Comment comment in comments) commentInfos.Add((CommentInfo)commentCreator.Create(comment, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient));
            return PartialView(commentInfos);
        }
        public ActionResult Descriptions(int id, string Description)
        {
            if (Description != null) postClient.ChangeDescription(id, Description);
            return PartialView((object)postClient.GetPost(id).Description);
        }
        #endregion

        #region Base
        protected override void ExecuteCore()
        {
            int culture = 0;
            if (HttpContext.Request.Cookies == null || HttpContext.Request.Cookies["CurrentCulture"] == null)
            {
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["Culture"], out culture);
                HttpContext.Response.Cookies["CurrentCulture"].Value = culture.ToString();
            }
            else culture = int.Parse(HttpContext.Request.Cookies["CurrentCulture"].Value);

            CultureHelper.CurrentCulture = culture;
            base.ExecuteCore();
        }
        protected override bool DisableAsyncSupport
        {
            get { return true; }
        }
        #endregion
    }
}
