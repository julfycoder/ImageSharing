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
    public class TapeHelper
    {
        IImageSharingRepository repository;
        public TapeHelper(IImageSharingRepository repository)
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
    }
}
