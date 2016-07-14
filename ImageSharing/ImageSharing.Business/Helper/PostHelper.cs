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
    public class PostHelper
    {
        IImageSharingRepository repository;
        public PostHelper(IImageSharingRepository repository)
        {
            this.repository = repository;
        }
        public void AddPost(Post post)
        {
            repository.AddEntity(post);
            repository.SaveChanges();
        }
        public void RemovePost(int id)
        {
            repository.RemoveEntity(GetPost(id));
            repository.SaveChanges();
        }
        public Post GetPost(int id)
        {
            return repository.Posts.ToList().First(p => p.ID == id);
        }
        public IEnumerable<Post> GetPosts()
        {
            return repository.Posts;
        }
        
        public void ChangeImagePath(int id, string imagePath)
        {
            Post post = GetPost(id);
            post.ImagePath = imagePath;
            repository.SaveChanges();
        }
        public void ChangeDateTime(int id, DateTime dateTime)
        {
            Post post = GetPost(id);
            post.DateTime = dateTime;
            repository.SaveChanges();
        }
        public void ChangeDescription(int id, string text)
        {
            Post post = GetPost(id);
            post.Description = text;
            repository.SaveChanges();
        }
    }
}
