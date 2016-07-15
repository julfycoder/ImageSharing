using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.DAL.Entity;
using ImageSharing.DAL;

namespace ImageSharing.Business.Helper
{
    [Serializable]
    public class UserHelper
    {
        IImageSharingRepository repository;
        public UserHelper(IImageSharingRepository repository)
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
        
        public void ActivateAccount(int id)
        {
            UserAccount user = GetUser(id);
            user.IsActivated = true;
            repository.SaveChanges();
        }
        public void ChangeRole(int id, string role)
        {
            UserAccount user = GetUser(id);
            user.Role = role;
            repository.SaveChanges();
        }
    }
}
