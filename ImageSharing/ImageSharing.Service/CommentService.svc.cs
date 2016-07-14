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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CommentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CommentService.svc or CommentService.svc.cs at the Solution Explorer and start debugging.
    public class CommentService : ICommentService
    {
        CommentHelper helper = new CommentHelper(new Repository());
        public void ChangeText(int id,string text)
        {
            helper.ChangeText(id,text);
        }

        public Comment GetComment(int id)
        {
            return helper.GetComment(id);
        }

        public IEnumerable<Comment> GetComments()
        {
            return helper.GetComments();
        }

        public void AddComment(Comment comment)
        {
            helper.AddComment(comment);
        }

        public void RemoveComment(int id)
        {
            helper.RemoveComment(id);
        }
    }
}
