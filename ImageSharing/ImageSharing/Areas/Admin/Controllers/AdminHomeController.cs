using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageSharing.Models;
using ImageSharing.Models.EntityInfo;
using ImageSharing.DAL;
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
using ImageSharing.Areas.Admin.Models;
using System.IO;

namespace ImageSharing.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        //
        // GET: /Admin/AdminHome/
        UserServiceClient userClient = new UserServiceClient();
        TapeServiceClient tapeClient = new TapeServiceClient();
        PostServiceClient postClient = new PostServiceClient();
        SubscriptionServiceClient subClient = new SubscriptionServiceClient();
        CommentServiceClient commentClient = new CommentServiceClient();
        FriendshipServiceClient friendshipClient = new FriendshipServiceClient();
        FriendshipRequestServiceClient requestClient = new FriendshipRequestServiceClient();

        public ActionResult AdministrationPage()
        {
            return View();
        }
        public ActionResult UsersConsolePage()
        {
            IEnumerable<UserAccount> users = userClient.GetUsers();
            UserAccountInfoCreator userCreator = new UserAccountInfoCreator();
            List<UserAccountInfo> userInfos = new List<UserAccountInfo>();
            foreach (UserAccount user in users) userInfos.Add((UserAccountInfo)userCreator.Create(user, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient));
            return PartialView(userInfos);
        }
        public ActionResult PostsConsolePage()
        {
            IEnumerable<Post> posts = postClient.GetPosts();
            PostInfoCreator postCreator = new PostInfoCreator();
            List<PostInfo> postInfos = new List<PostInfo>();
            foreach (Post post in posts) postInfos.Add((PostInfo)postCreator.Create(post, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient));
            return PartialView(postInfos);
        }
        public ActionResult CommentsConsolePage()
        {
            IEnumerable<Post> posts = postClient.GetPosts();
            PostInfoCreator postCreator = new PostInfoCreator();
            List<PostInfo> postInfos = new List<PostInfo>();
            foreach (Post post in posts) postInfos.Add((PostInfo)postCreator.Create(post, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient));
            return PartialView(postInfos);
        }
        [HttpPost]
        public ActionResult ChangeUsers(List<UserAccountInfo> users, List<HttpPostedFileBase> avatars)
        {
            int userCount = 0;
            foreach (UserAccountInfo userInfo in users)
            {
                UserAccount user = userClient.GetUser(userInfo.ID);
                if (userInfo.Surname != user.Surname) userClient.ChangeSurname(userInfo.ID, userInfo.Surname);
                if (userInfo.Name != user.Name) userClient.ChangeName(userInfo.ID, userInfo.Name);
                if (userInfo.Email != user.Email) userClient.ChangeEmail(userInfo.ID, userInfo.Email);
                if (userInfo.Role != user.Role) userClient.ChangeRole(userInfo.ID, userInfo.Role);
                if (avatars[userCount] != null && avatars[userCount].FileName != "" && userInfo.AvatarPath != Path.GetFileName(avatars[userCount].FileName))
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + @"Content\AvatarImages\";
                    string fileName = Path.GetFileName(avatars[userCount].FileName);
                    string rootPath = Path.Combine(path, fileName);
                    if (fileName != null) avatars[userCount].SaveAs(rootPath);

                    userClient.ChangeAvatarPath(userInfo.ID, avatars[userCount].FileName);
                }
                userCount++;
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult ChangePosts(List<PostInfo> posts, List<HttpPostedFileBase> images)
        {
            int postCount = 0;
            foreach (PostInfo postInfo in posts)
            {
                Post post = postClient.GetPost(postInfo.ID);
                if (post.DateTime != postInfo.DateTime) postClient.ChangeDataTime(postInfo.ID, postInfo.DateTime);
                if (post.Description != postInfo.Description) postClient.ChangeDescription(postInfo.ID, postInfo.Description);
                if (images[postCount] != null && images[postCount].FileName != "" && postInfo.ImagePath != Path.GetFileName(images[postCount].FileName))
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + @"Content\UploadedImages\";
                    string fileName = Path.GetFileName(images[postCount].FileName);
                    string rootPath = Path.Combine(path, fileName);
                    if (fileName != null) images[postCount].SaveAs(rootPath);

                    postClient.ChangeImagePath(postInfo.ID, images[postCount].FileName);
                }
                postCount++;
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult ChangeComments(List<CommentInfo> comments)
        {
            foreach (CommentInfo commentInfo in comments)
            {
                Comment comment = commentClient.GetComment(commentInfo.ID);
                if (comment.Text != commentInfo.Text) commentClient.ChangeText(commentInfo.ID, commentInfo.Text);
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult DeleteUser(int id)
        {
            IEnumerable<Friendship> deletedFriendships = null;
            if (friendshipClient.GetFriendships().Any(f => f.User1ID == id || f.User2ID == id))
            {
                deletedFriendships = friendshipClient.GetFriendships().Where(f => f.User1ID == id || f.User2ID == id);
                foreach (Friendship friendship in deletedFriendships) friendshipClient.RemoveFriendship(friendship.ID); //deleting frienships
            }

            IEnumerable<FriendshipRequest> deletedRequests = null;
            if (requestClient.GetRequests().Any(r => r.AskerID == id || r.DestinationID == id))
            {
                deletedRequests = requestClient.GetRequests().Where(r => r.AskerID == id || r.DestinationID == id);
                foreach (FriendshipRequest request in deletedRequests) requestClient.RemoveRequest(request.ID);         //deleting requests
            }

            IEnumerable<Subscription> deletedSubs = null;
            if (subClient.GetSubscriptions().Any(s => s.UserID == id || s.FollowerID == id))
            {
                deletedSubs = subClient.GetSubscriptions().Where(s => s.UserID == id || s.FollowerID == id);
                foreach (Subscription sub in deletedSubs) subClient.RemoveSubscription(sub.ID);                     //deleting subs
            }

            Tape deletedTape = tapeClient.GetTapes().First(t => t.UserID == id);

            IEnumerable<Post> deletedPosts = null;
            if (postClient.GetPosts().Any(p => p.TapeID == deletedTape.ID))
            {
                deletedPosts = postClient.GetPosts().Where(p => p.TapeID == deletedTape.ID);
            }

            IEnumerable<Comment> deletedComments = null;
            if(deletedPosts!=null)
            foreach (Post post in deletedPosts)
            {
                if (commentClient.GetComments().Any(c => c.PostID == post.ID)) deletedComments = commentClient.GetComments().Where(c => c.PostID == post.ID);//Deleting comments
            }
            if (deletedComments != null) foreach (Comment comment in deletedComments) commentClient.RemoveComment(comment.ID);

            if(deletedPosts!=null)
            foreach (Post post in deletedPosts) postClient.RemovePost(post.ID);                                         //deleting posts
            tapeClient.RemoveTape(deletedTape.ID);                                                                      //deleting tape






            UserAccount deletedUser = userClient.GetUser(id);
            userClient.RemoveUser(id);                                                                                  //deleting user

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult DeletePost(int id)
        {
            IEnumerable<Comment> deletedComments = null;
            if (commentClient.GetComments().Any(c => c.PostID == id))
            {
                deletedComments = commentClient.GetComments().Where(c => c.PostID == id);
                foreach (Comment comment in deletedComments) commentClient.RemoveComment(comment.ID);
            }

            postClient.RemovePost(id);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult DeleteComment(int id)
        {
            commentClient.RemoveComment(id);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult AddUser(RegisterModel model, HttpPostedFileBase Avatar)
        {
            string fileName = "";
            if (Avatar != null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"Content\AvatarImages\";
                fileName = Path.GetFileName(Avatar.FileName);
                string rootPath = Path.Combine(path, fileName);
                if (fileName != null) Avatar.SaveAs(rootPath);
            }
            UserAccount user = new UserAccount()
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Password = Scrambler.GetMD5Hash(model.Password),
                IsActivated = true,
                Role = model.Role,
                AvatarPath = fileName
            };
            userClient.AddUser(user);
            Tape tape = new Tape
            {
                UserID = userClient.GetUsers().Last().ID,
            };
            tapeClient.AddTape(tape);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult AddPost(PostModel model,HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"Content\UploadedImages\";
                string fileName = Path.GetFileName(Image.FileName);
                string rootPath = Path.Combine(path, fileName);
                if (fileName != null) Image.SaveAs(rootPath);
            }
            Post post = new Post
            {
                AuthorID = model.AuthorID,
                DateTime = DateTime.Now,
                ImagePath = Path.GetFileName(Image.FileName),
                Description = model.Description,
                TapeID = tapeClient.GetTapes().First(t=>t.UserID==model.AuthorID).ID
            };
            postClient.AddPost(post);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult AddComment(CommentModel model)
        {
            Comment comment = new Comment 
            {
                Text=model.Text,
                PostID=model.PostID
            };
            commentClient.AddComment(comment);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
    }
}
