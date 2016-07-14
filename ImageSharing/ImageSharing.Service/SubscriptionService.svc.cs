using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.DAL;
using ImageSharing.Business;
using ImageSharing.DAL.Entity;

namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SubscriptionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SubscriptionService.svc or SubscriptionService.svc.cs at the Solution Explorer and start debugging.
    public class SubscriptionService : ISubscriptionService
    {
        SubscriptionHelper helper = new SubscriptionHelper(new Repository());
        public void AddSubscription(DAL.Entity.Subscription subscription)
        {
            helper.AddSubscription(subscription);
        }

        public void RemoveSubscription(int id)
        {
            helper.RemoveSubscription(id);
        }

        public DAL.Entity.Subscription GetSubscription(int id)
        {
            return helper.GetSubscription(id);
        }

        public IEnumerable<DAL.Entity.Subscription> GetSubscriptions()
        {
            return helper.GetSubscriptions();
        }
    }
}
