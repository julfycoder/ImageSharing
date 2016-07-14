using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.Business;
using ImageSharing.DAL;
using ImageSharing.DAL.Entity;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommentService" in both code and config file together.
    [ServiceContract]
    public interface ICommentService
    {
        [OperationContract]
        void ChangeText(int id,string text);

        [OperationContract]
        Comment GetComment(int id);

        [OperationContract]
        IEnumerable<Comment> GetComments();

        [OperationContract]
        void AddComment(Comment comment);

        [OperationContract]
        void RemoveComment(int id);
    }
}
