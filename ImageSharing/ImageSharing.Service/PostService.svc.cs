using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.DAL;
using ImageSharing.Business;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PostService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PostService.svc or PostService.svc.cs at the Solution Explorer and start debugging.
    public class PostService : IPostService
    {
        PostHelper helper = new PostHelper(new Repository());
        public void AddComment(int id, int commentId)
        {
            helper.AddComment(id, commentId);
        }

        public void RemoveComment(int id, int commentId)
        {
            helper.RemoveComment(id, commentId);
        }

        public void ChangeImagePath(int id, string photoPath)
        {
            helper.ChangeImagePath(id, photoPath);
        }

        public void ChangeDataTime(int id, DateTime dateTime)
        {
            helper.ChangeDateTime(id, dateTime);
        }

        public DAL.Entity.Post GetPost(int id)
        {
            return helper.GetPost(id);
        }

        public IEnumerable<DAL.Entity.Post> GetPosts()
        {
            return helper.GetPosts();
        }

        public void AddPost(DAL.Entity.Post post)
        {
            helper.AddPost(post);
        }

        public void RemovePost(int id)
        {
            helper.RemovePost(id);
        }

        public IEnumerable<DAL.Entity.Comment> GetComments(int id)
        {
            return helper.GetComments(id);
        }

        public void ChangeDescription(int id, string text)
        {
            helper.ChangeDescription(id, text);
        }
    }
}
