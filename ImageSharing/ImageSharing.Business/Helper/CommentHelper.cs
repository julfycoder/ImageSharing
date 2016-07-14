using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.DAL;
using ImageSharing.DAL.Entity;

namespace ImageSharing.Business.Helper
{
    [Serializable]
    public class CommentHelper
    {
        IImageSharingRepository repository;

        public CommentHelper(IImageSharingRepository repository)
        {
            this.repository = repository;
        }
        public void AddComment(Comment comment)
        {
            repository.AddEntity(comment);
            repository.SaveChanges();
        }
        public void RemoveComment(int id)
        {
            repository.RemoveEntity(GetComment(id));
            repository.SaveChanges();
        }
        public Comment GetComment(int id)
        {
            return repository.Comments.ToList().First(c => c.ID == id);
        }
        public IEnumerable<Comment> GetComments()
        {
            return repository.Comments;
        }
        public void ChangeText(int id, string text)
        {
            Comment comment = GetComment(id);
            comment.Text = text;
            repository.SaveChanges();
        }
    }
}
