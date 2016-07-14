using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.DAL;
using ImageSharing.DAL.Entity;
using ImageSharing.Business.Helper;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PostServiceNew" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PostServiceNew.svc or PostServiceNew.svc.cs at the Solution Explorer and start debugging.
    public class PostServiceNew : IPostService
    {
        PostHelper helper = new PostHelper(new ImageSharingRepository());
        
        public void ChangeImagePath(int id, string photoPath)
        {
            helper.ChangeImagePath(id, photoPath);
        }

        public void ChangeDataTime(int id, DateTime dateTime)
        {
            helper.ChangeDateTime(id, dateTime);
        }

        public Post GetPost(int id)
        {
            return helper.GetPost(id);
        }

        public IEnumerable<Post> GetPosts()
        {
            return helper.GetPosts();
        }

        public void AddPost(Post post)
        {
            helper.AddPost(post);
        }

        public void RemovePost(int id)
        {
            helper.RemovePost(id);
        }
        public void ChangeDescription(int id, string text)
        {
            helper.ChangeDescription(id, text);
        }
    }
}
