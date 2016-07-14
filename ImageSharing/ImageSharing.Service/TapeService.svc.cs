using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.Business.Helper;
using ImageSharing.DAL.Entity;
using ImageSharing.DAL;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TapeServiceNew" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TapeServiceNew.svc or TapeServiceNew.svc.cs at the Solution Explorer and start debugging.
    public class TapeServiceNew : ITapeService
    {
        TapeHelper helper = new TapeHelper(new ImageSharingRepository());

        public Tape GetTape(int id)
        {
            return helper.GetTape(id);
        }

        public IEnumerable<Tape> GetTapes()
        {
            return helper.GetTapes();
        }

        public void AddTape(Tape tape)
        {
            helper.AddTape(tape);
        }

        public void RemoveTape(int id)
        {
            helper.RemoveTape(id);
        }
    }
}
