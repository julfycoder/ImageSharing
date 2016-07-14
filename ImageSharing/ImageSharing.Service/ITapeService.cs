using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.DAL.Entity;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITapeServiceNew" in both code and config file together.
    [ServiceContract]
    public interface ITapeService
    {
        [OperationContract]
        Tape GetTape(int id);

        [OperationContract]
        IEnumerable<Tape> GetTapes();

        [OperationContract]
        void AddTape(Tape tape);

        [OperationContract]
        void RemoveTape(int id);
    }
}
