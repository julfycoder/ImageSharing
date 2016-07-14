﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImageSharing.SubscriptionServiceNew {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SubscriptionServiceNew.ISubscriptionServiceNew")]
    public interface ISubscriptionServiceNew {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionServiceNew/AddSubscription", ReplyAction="http://tempuri.org/ISubscriptionServiceNew/AddSubscriptionResponse")]
        void AddSubscription(ImageSharing.DAL.EntityNew.Subscription subscription);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionServiceNew/AddSubscription", ReplyAction="http://tempuri.org/ISubscriptionServiceNew/AddSubscriptionResponse")]
        System.Threading.Tasks.Task AddSubscriptionAsync(ImageSharing.DAL.EntityNew.Subscription subscription);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionServiceNew/RemoveSubscription", ReplyAction="http://tempuri.org/ISubscriptionServiceNew/RemoveSubscriptionResponse")]
        void RemoveSubscription(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionServiceNew/RemoveSubscription", ReplyAction="http://tempuri.org/ISubscriptionServiceNew/RemoveSubscriptionResponse")]
        System.Threading.Tasks.Task RemoveSubscriptionAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionServiceNew/GetSubscription", ReplyAction="http://tempuri.org/ISubscriptionServiceNew/GetSubscriptionResponse")]
        ImageSharing.DAL.EntityNew.Subscription GetSubscription(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionServiceNew/GetSubscription", ReplyAction="http://tempuri.org/ISubscriptionServiceNew/GetSubscriptionResponse")]
        System.Threading.Tasks.Task<ImageSharing.DAL.EntityNew.Subscription> GetSubscriptionAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionServiceNew/GetSubscriptions", ReplyAction="http://tempuri.org/ISubscriptionServiceNew/GetSubscriptionsResponse")]
        ImageSharing.DAL.EntityNew.Subscription[] GetSubscriptions();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionServiceNew/GetSubscriptions", ReplyAction="http://tempuri.org/ISubscriptionServiceNew/GetSubscriptionsResponse")]
        System.Threading.Tasks.Task<ImageSharing.DAL.EntityNew.Subscription[]> GetSubscriptionsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISubscriptionServiceNewChannel : ImageSharing.SubscriptionServiceNew.ISubscriptionServiceNew, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SubscriptionServiceNewClient : System.ServiceModel.ClientBase<ImageSharing.SubscriptionServiceNew.ISubscriptionServiceNew>, ImageSharing.SubscriptionServiceNew.ISubscriptionServiceNew {
        
        public SubscriptionServiceNewClient() {
        }
        
        public SubscriptionServiceNewClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SubscriptionServiceNewClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SubscriptionServiceNewClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SubscriptionServiceNewClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddSubscription(ImageSharing.DAL.EntityNew.Subscription subscription) {
            base.Channel.AddSubscription(subscription);
        }
        
        public System.Threading.Tasks.Task AddSubscriptionAsync(ImageSharing.DAL.EntityNew.Subscription subscription) {
            return base.Channel.AddSubscriptionAsync(subscription);
        }
        
        public void RemoveSubscription(int id) {
            base.Channel.RemoveSubscription(id);
        }
        
        public System.Threading.Tasks.Task RemoveSubscriptionAsync(int id) {
            return base.Channel.RemoveSubscriptionAsync(id);
        }
        
        public ImageSharing.DAL.EntityNew.Subscription GetSubscription(int id) {
            return base.Channel.GetSubscription(id);
        }
        
        public System.Threading.Tasks.Task<ImageSharing.DAL.EntityNew.Subscription> GetSubscriptionAsync(int id) {
            return base.Channel.GetSubscriptionAsync(id);
        }
        
        public ImageSharing.DAL.EntityNew.Subscription[] GetSubscriptions() {
            return base.Channel.GetSubscriptions();
        }
        
        public System.Threading.Tasks.Task<ImageSharing.DAL.EntityNew.Subscription[]> GetSubscriptionsAsync() {
            return base.Channel.GetSubscriptionsAsync();
        }
    }
}
