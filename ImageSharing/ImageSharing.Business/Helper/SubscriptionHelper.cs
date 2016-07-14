using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.DAL;
using ImageSharing.DAL.EntityNew;

namespace ImageSharing.Business.Helper
{
    [Serializable]
    public class SubscriptionHelper
    {
        IImageSharingRepository repository;
        public SubscriptionHelper(IImageSharingRepository repository)
        {
            this.repository = repository;
        }
        public void AddSubscription(Subscription subscription)
        {
            repository.AddEntity(subscription);
            repository.SaveChanges();
        }
        public void RemoveSubscription(int id)
        {
            repository.RemoveEntity(GetSubscription(id));
            repository.SaveChanges();
        }
        public Subscription GetSubscription(int id)
        {
            return repository.Subscriptions.ToList().First(s => s.ID == id);
        }
        public IEnumerable<Subscription> GetSubscriptions()
        {
            return repository.Subscriptions;
        }
    }
}
