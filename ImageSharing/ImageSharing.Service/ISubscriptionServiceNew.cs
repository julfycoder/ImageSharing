using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.DAL.EntityNew;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISubscriptionServiceNew" in both code and config file together.
    [ServiceContract]
    public interface ISubscriptionServiceNew
    {
        [OperationContract]
        void AddSubscription(Subscription subscription);

        [OperationContract]
        void RemoveSubscription(int id);

        [OperationContract]
        Subscription GetSubscription(int id);

        [OperationContract]
        IEnumerable<Subscription> GetSubscriptions();
    }
}
