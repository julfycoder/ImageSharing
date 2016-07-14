using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.DAL.Entity;
using ImageSharing.DAL;

namespace ImageSharing.Business
{
    [Serializable]
    public class PostHelper
    {
        IRepository repository;
        public PostHelper(IRepository repository)
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
        public void AddComment(int id, int commentId)
        {
            Post post = GetPost(id);
            if (post.IDsComments == null) post.IDsComments = "";
            if (post.IDsComments.Count() == 0) post.IDsComments += commentId.ToString();
            else post.IDsComments += "," + commentId.ToString();
            repository.SaveChanges();
        }
        public void RemoveComment(int id, int commentId)
        {
            Post post = GetPost(id);
            string[] IDsComments = post.IDsComments.Split(',');
            post.IDsComments = "";
            foreach (string comment in IDsComments)
            {
                if (comment != commentId.ToString())
                {
                    if (post.IDsComments.Count() == 0)
                    {
                        post.IDsComments += comment;
                    }
                    else post.IDsComments += "," + comment;
                }
            }
            repository.SaveChanges();
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
        public IEnumerable<Comment> GetComments(int id)
        {
            List<string> IDs = new List<string>();
            Post post = GetPost(id);
            if (post.IDsComments != null && post.IDsComments != "") IDs.AddRange(post.IDsComments.Split(','));
            List<Comment> comments = new List<Comment>();
            foreach (string commentId in IDs)
            {
                comments.Add(repository.Comments.ToList().First(c => c.ID == int.Parse(commentId)));
            }
            return comments;
        }
    }
}
