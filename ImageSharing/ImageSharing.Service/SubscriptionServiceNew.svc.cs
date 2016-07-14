using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.DAL;
using ImageSharing.DAL.EntityNew;
using ImageSharing.Business.Helper;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SubscriptionServiceNew" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SubscriptionServiceNew.svc or SubscriptionServiceNew.svc.cs at the Solution Explorer and start debugging.
    public class SubscriptionServiceNew : ISubscriptionServiceNew
    {
        SubscriptionHelper helper = new SubscriptionHelper(new ImageSharingRepository());
        public void AddSubscription(Subscription subscription)
        {
            helper.AddSubscription(subscription);
        }

        public void RemoveSubscription(int id)
        {
            helper.RemoveSubscription(id);
        }

        public Subscription GetSubscription(int id)
        {
            return helper.GetSubscription(id);
        }

        public IEnumerable<Subscription> GetSubscriptions()
        {
            return helper.GetSubscriptions();
        }
    }
}
