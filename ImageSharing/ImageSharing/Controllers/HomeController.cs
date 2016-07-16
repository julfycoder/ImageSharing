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
using ImageSharing.Mail;
using ImageSharing.Models.InfoCreator;
using ImageSharing.Security;
using ImageSharing.Culture;

namespace ImageSharing.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        UserServiceClient userClient = new UserServiceClient();
        TapeServiceClient tapeClient = new TapeServiceClient();
        PostServiceClient postClient = new PostServiceClient();
        SubscriptionServiceClient subClient = new SubscriptionServiceClient();
        CommentServiceClient commentClient = new CommentServiceClient();
        FriendshipServiceClient friendshipClient = new FriendshipServiceClient();
        FriendshipRequestServiceClient requestClient = new FriendshipRequestServiceClient();

        #region Actions
        public ActionResult Index()
        {
            if (HttpContext.Request.Cookies == null) HttpContext.Response.Cookies["ID"].Value = "";
            if (HttpContext.Request.Cookies != null && HttpContext.Request.Cookies["Role"] != null && (HttpContext.Request.Cookies["Role"].Value == "user" || HttpContext.Request.Cookies["Role"].Value == "admin"))
            {
                return RedirectToAction("Home", "UserHome", new { area = "User" });
            }
            return View("LoginPage");
        }
        public ActionResult LoginPage()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            
            UserAccount user = new UserAccount();
            if (!userClient.GetUsers().Any(u => u.Email == model.Email && u.Password == Scrambler.GetMD5Hash(model.Password)))
            {
                ViewBag.Message = "Password or email is incorrect!";
                return View("LoginPage");
            }

            user = userClient.GetUsers().First(u => u.Email == model.Email && u.Password == Scrambler.GetMD5Hash(model.Password));
            if (user.IsActivated)
            {
                HttpContext.Response.Cookies["Role"].Value = user.Role;
                HttpContext.Response.Cookies["ID"].Value = user.ID.ToString();
                return RedirectToAction("Home", "UserHome", new { area = "User" });
            }
            else ViewBag.Message = "This account is not activated!";
            return View("LoginPage");
        }
        public ActionResult RegisterPage()
        {
            return View();
        }
        public ActionResult Register(RegisterModel model)
        {
                UserAccount user = new UserAccount()
                {
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    Password = Scrambler.GetMD5Hash(model.Password),
                    IsActivated = false,
                    Role = "user"
                };
                userClient.AddUser(user);

                ImageSharingMailMessanger msg = new ImageSharingMailMessanger();
                msg.Send("image.sharing@mail.ru", "314159265IS", model.Email, "Apply registration", HttpContext.Request.Url.Scheme + "://" + HttpContext.Request.Url.Authority + "/Home/ApplyRegisterPage");
                return View("LoginPage");
        }
        public ActionResult AboutPage()
        {
            return View();
        }
        public ActionResult PrivatePolicyPage()
        {
            return View();
        }
        public ActionResult ApplyRegisterPage()
        {
            return View();
        }
        public ActionResult ApplyRegister(LoginModel model)
        {
            string email = userClient.GetUsers().ToList()[0].Email;
            string password = userClient.GetUsers().ToList()[0].Password;
            if (userClient.GetUsers().Any(u => u.Email == model.Email && Scrambler.GetMD5Hash(model.Password) == u.Password))
            {
                UserAccount user = userClient.GetUsers().First(u => u.Email == model.Email && Scrambler.GetMD5Hash(model.Password) == u.Password);
                HttpContext.Response.Cookies["Role"].Value = user.Role;
                HttpContext.Response.Cookies["ID"].Value = user.ID.ToString();

                userClient.ActivateAccount(user.ID);

                IEnumerable<Tape> tapes = tapeClient.GetTapes();

                int tapeID = 0;
                if (tapes.Count() > 0) tapeID = tapes.ToArray()[tapes.Count() - 1].ID;
                Tape tape = new Tape { ID = tapeID + 1, UserID = user.ID };

                tapeClient.AddTape(tape);

                return RedirectToAction("Home", "UserHome", new { area = "User" });
            }
            ViewBag.Message = "Email or password is incorrect!";
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult RecoveryPage()
        {
            return View();
        }
        public ActionResult Recovery(RecoveryModel model)
        {
            string password = Scrambler.GeneratePassword();

            if (!userClient.GetUsers().Any(u => u.Email == model.Email))
            {
                ViewBag.Message = "Such email does not exist!";
                return Redirect("RecoveryPage");
            }
            UserAccount user = userClient.GetUsers().First(u => u.Email == model.Email);
            userClient.ChangePassword(user.ID, Scrambler.GetMD5Hash(password));
            ImageSharingMailMessanger msg = new ImageSharingMailMessanger();
            msg.Send("image.sharing@mail.ru", "314159265IS", model.Email, "Recover password", password);
            return View("LoginPage");
        }
        public ActionResult UsersPage(string searchString = "")
        {
            UserAccountInfoCreator userCreator = new UserAccountInfoCreator();

            List<UserAccountInfo> userInfos = new List<UserAccountInfo>();
            IEnumerable<UserAccount> users = userClient.GetUsers();
            if (users.Count() > 0)
            {
                foreach (UserAccount user in users)
                {
                    if (HttpContext.Request.Cookies["ID"].Value == "" || user.ID != int.Parse(HttpContext.Request.Cookies["ID"].Value))
                        if (user.Name.ToLower().Contains(searchString.ToLower()) || user.Surname.ToLower().Contains(searchString.ToLower()))
                            userInfos.Add((UserAccountInfo)userCreator.Create(user, userClient, postClient, tapeClient,friendshipClient,commentClient,subClient));
                }
            }
            if (userInfos.Count() < 1) ViewBag.SearchResult = "Nothing found";

            return View(userInfos);
        }
        public ActionResult UserPage(int id)
        {
            int ID=0;
            if (HttpContext.Request.Cookies != null && HttpContext.Request.Cookies["ID"].Value != "") ID = int.Parse(HttpContext.Request.Cookies["ID"].Value);
            UserAccountInfo userInfo = (UserAccountInfo)new UserAccountInfoCreator().Create(userClient.GetUser(id), userClient, postClient, tapeClient,friendshipClient,commentClient,subClient);
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

            if (HttpContext.Request.Cookies != null && HttpContext.Request.Cookies["ID"] != null && HttpContext.Request.Cookies["ID"].Value != "")
            {
                List<FriendInfo> friends = new List<FriendInfo>();
                List<UserAccount> userFriends = new List<UserAccount>();
                IEnumerable<Friendship> friendships = friendshipClient.GetFriendships().Where(f => f.User1ID == ID || f.User2ID == ID);
                foreach (Friendship f in friendships)
                {
                    if (f.User1ID == ID) userFriends.Add(userClient.GetUser(f.User2ID));
                    if (f.User2ID == ID) userFriends.Add(userClient.GetUser(f.User1ID));
                }

                foreach (UserAccount friend in userFriends) friends.Add((FriendInfo)new FriendInfoCreator().Create(friend, userClient, postClient, tapeClient, friendshipClient, commentClient, subClient));

                ViewBag.IsFriend = "false";
                foreach (FriendInfo friend in friends)
                {
                    if (id == friend.ID)
                    {
                        ViewBag.IsFriend = "true";
                        break;
                    }
                }
                List<Subscription> subs = new List<Subscription>();
                if (subClient.GetSubscriptions().Any(s => s.FollowerID == ID)) subs.AddRange(subClient.GetSubscriptions().Where(s => s.FollowerID == ID));
                ViewBag.IsFollow = "false";
                foreach (Subscription sub in subs)
                {
                    if (id == sub.UserID)
                    {
                        ViewBag.IsFollow = "true";
                        break;
                    }
                }
            }
            if (requestClient.GetRequests().Any(r => r.AskerID == ID && r.DestinationID == id)) ViewBag.ThereIsRequest = "true";
            else ViewBag.ThereIsRequest = "false";
            return View(userInfo);
        }

        public ActionResult ChangeCurrentCulture(int id)
        {
            CultureHelper.CurrentCulture = id;

            HttpContext.Response.Cookies["CurrentCulture"].Value = id.ToString();

            return Redirect(Request.UrlReferrer.ToString());
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
