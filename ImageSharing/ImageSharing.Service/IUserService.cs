using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.DAL.Entity;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserServiceNew" in both code and config file together.
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
        void ChangeName(int id, string name);

        [OperationContract]
        void ChangeSurname(int id, string surname);

        [OperationContract]
        void ChangeEmail(int id, string email);

        [OperationContract]
        void ChangePassword(int id, string password);

        [OperationContract]
        void ChangeAvatarPath(int id, string avatarPath);

        [OperationContract]
        void RemoveUser(int id);

        [OperationContract]
        void ActivateAccount(int id);

    }
}
