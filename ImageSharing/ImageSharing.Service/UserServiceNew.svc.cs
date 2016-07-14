using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.Business.Helper;
using ImageSharing.DAL.EntityNew;
using ImageSharing.DAL;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserServiceNew" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserServiceNew.svc or UserServiceNew.svc.cs at the Solution Explorer and start debugging.
    public class UserServiceNew : IUserServiceNew
    {
        UserHelper helper = new UserHelper(new ImageSharingRepository());
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

        public void RemoveUser(int id)
        {
            helper.RemoveUser(id);
        }

        public void ActivateAccount(int id)
        {
            helper.ActivateAccount(id);
        }
    }
}
