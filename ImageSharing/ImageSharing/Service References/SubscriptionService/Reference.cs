﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImageSharing.SubscriptionService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SubscriptionService.ISubscriptionService")]
    public interface ISubscriptionService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionService/AddSubscription", ReplyAction="http://tempuri.org/ISubscriptionService/AddSubscriptionResponse")]
        void AddSubscription(ImageSharing.DAL.Entity.Subscription subscription);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionService/AddSubscription", ReplyAction="http://tempuri.org/ISubscriptionService/AddSubscriptionResponse")]
        System.Threading.Tasks.Task AddSubscriptionAsync(ImageSharing.DAL.Entity.Subscription subscription);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionService/RemoveSubscription", ReplyAction="http://tempuri.org/ISubscriptionService/RemoveSubscriptionResponse")]
        void RemoveSubscription(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionService/RemoveSubscription", ReplyAction="http://tempuri.org/ISubscriptionService/RemoveSubscriptionResponse")]
        System.Threading.Tasks.Task RemoveSubscriptionAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionService/GetSubscription", ReplyAction="http://tempuri.org/ISubscriptionService/GetSubscriptionResponse")]
        ImageSharing.DAL.Entity.Subscription GetSubscription(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionService/GetSubscription", ReplyAction="http://tempuri.org/ISubscriptionService/GetSubscriptionResponse")]
        System.Threading.Tasks.Task<ImageSharing.DAL.Entity.Subscription> GetSubscriptionAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionService/GetSubscriptions", ReplyAction="http://tempuri.org/ISubscriptionService/GetSubscriptionsResponse")]
        ImageSharing.DAL.Entity.Subscription[] GetSubscriptions();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionService/GetSubscriptions", ReplyAction="http://tempuri.org/ISubscriptionService/GetSubscriptionsResponse")]
        System.Threading.Tasks.Task<ImageSharing.DAL.Entity.Subscription[]> GetSubscriptionsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISubscriptionServiceChannel : ImageSharing.SubscriptionService.ISubscriptionService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SubscriptionServiceClient : System.ServiceModel.ClientBase<ImageSharing.SubscriptionService.ISubscriptionService>, ImageSharing.SubscriptionService.ISubscriptionService {
        
        public SubscriptionServiceClient() {
        }
        
        public SubscriptionServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SubscriptionServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SubscriptionServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SubscriptionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddSubscription(ImageSharing.DAL.Entity.Subscription subscription) {
            base.Channel.AddSubscription(subscription);
        }
        
        public System.Threading.Tasks.Task AddSubscriptionAsync(ImageSharing.DAL.Entity.Subscription subscription) {
            return base.Channel.AddSubscriptionAsync(subscription);
        }
        
        public void RemoveSubscription(int id) {
            base.Channel.RemoveSubscription(id);
        }
        
        public System.Threading.Tasks.Task RemoveSubscriptionAsync(int id) {
            return base.Channel.RemoveSubscriptionAsync(id);
        }
        
        public ImageSharing.DAL.Entity.Subscription GetSubscription(int id) {
            return base.Channel.GetSubscription(id);
        }
        
        public System.Threading.Tasks.Task<ImageSharing.DAL.Entity.Subscription> GetSubscriptionAsync(int id) {
            return base.Channel.GetSubscriptionAsync(id);
        }
        
        public ImageSharing.DAL.Entity.Subscription[] GetSubscriptions() {
            return base.Channel.GetSubscriptions();
        }
        
        public System.Threading.Tasks.Task<ImageSharing.DAL.Entity.Subscription[]> GetSubscriptionsAsync() {
            return base.Channel.GetSubscriptionsAsync();
        }
    }
}
