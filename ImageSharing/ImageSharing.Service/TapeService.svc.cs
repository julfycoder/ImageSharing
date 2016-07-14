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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TapeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TapeService.svc or TapeService.svc.cs at the Solution Explorer and start debugging.
    public class TapeService : ITapeService
    {
        TapeHelper helper = new TapeHelper(new Repository());
        public void AddPost(int id, int postId)
        {
            helper.AddPost(id, postId);
        }

        public void RemovePost(int id, int postId)
        {
            helper.RemovePost(id, postId);
        }

        public Tape GetTape(int id)
        {
            return helper.GetTape(id);
        }

        public IEnumerable<DAL.Entity.Tape> GetTapes()
        {
            return helper.GetTapes();
        }

        public void AddTape(DAL.Entity.Tape tape)
        {
            helper.AddTape(tape);
        }

        public void RemoveTape(int id)
        {
            helper.RemoveTape(id);
        }

        public IEnumerable<DAL.Entity.Post> GetPosts(int id)
        {
            return helper.GetPosts(id);
        }
    }
}
