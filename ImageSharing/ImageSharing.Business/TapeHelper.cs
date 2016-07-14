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
    public class TapeHelper
    {
        IRepository repository;
        public TapeHelper(IRepository repository)
        {
            this.repository = repository;
        }
        public void AddTape(Tape tape)
        {
            repository.AddEntity(tape);
            repository.SaveChanges();
        }
        public void RemoveTape(int id)
        {
            repository.RemoveEntity(GetTape(id));
            repository.SaveChanges();
        }
        public Tape GetTape(int id)
        {
            return repository.Tapes.ToList().First(t => t.ID == id);
        }
        public IEnumerable<Tape> GetTapes()
        {
            return repository.Tapes;
        }
        public void AddPost(int id, int postId)
        {
            Tape tape = GetTape(id);
            if (tape.IDsPosts == null) tape.IDsPosts = "";
            if (tape.IDsPosts.Count() == 0) tape.IDsPosts += postId.ToString();
            else tape.IDsPosts += "," + postId.ToString();
            repository.SaveChanges();
        }
        public void RemovePost(int id, int postId)
        {
            Tape tape = GetTape(id);
            string[] IDsPosts = tape.IDsPosts.Split(',');
            tape.IDsPosts = "";
            foreach (string post in IDsPosts)
            {
                if (post != postId.ToString())
                {
                    if (tape.IDsPosts.Count() == 0)
                    {
                        tape.IDsPosts += post;
                    }
                    else tape.IDsPosts += "," + post;
                }
            }
            repository.SaveChanges();
        }
        public IEnumerable<Post> GetPosts(int id)
        {

            List<string> IDs = new List<string>();
            if (GetTape(id).IDsPosts != null) IDs.AddRange(GetTape(id).IDsPosts.Split(','));
            List<Post> posts = new List<Post>();
            foreach (string postId in IDs)
            {
                posts.Add(repository.Posts.ToList().First(p => p.ID == int.Parse(postId)));
            }
            return posts;
        }
    }
}
