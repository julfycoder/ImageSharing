﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImageSharing.FriendshipRequestServiceNew {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FriendshipRequestServiceNew.IFriendshipRequestServiceNew")]
    public interface IFriendshipRequestServiceNew {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestServiceNew/GetRequest", ReplyAction="http://tempuri.org/IFriendshipRequestServiceNew/GetRequestResponse")]
        ImageSharing.DAL.EntityNew.FriendshipRequest GetRequest(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestServiceNew/GetRequest", ReplyAction="http://tempuri.org/IFriendshipRequestServiceNew/GetRequestResponse")]
        System.Threading.Tasks.Task<ImageSharing.DAL.EntityNew.FriendshipRequest> GetRequestAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestServiceNew/GetRequests", ReplyAction="http://tempuri.org/IFriendshipRequestServiceNew/GetRequestsResponse")]
        ImageSharing.DAL.EntityNew.FriendshipRequest[] GetRequests();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestServiceNew/GetRequests", ReplyAction="http://tempuri.org/IFriendshipRequestServiceNew/GetRequestsResponse")]
        System.Threading.Tasks.Task<ImageSharing.DAL.EntityNew.FriendshipRequest[]> GetRequestsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestServiceNew/AddRequest", ReplyAction="http://tempuri.org/IFriendshipRequestServiceNew/AddRequestResponse")]
        void AddRequest(ImageSharing.DAL.EntityNew.FriendshipRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestServiceNew/AddRequest", ReplyAction="http://tempuri.org/IFriendshipRequestServiceNew/AddRequestResponse")]
        System.Threading.Tasks.Task AddRequestAsync(ImageSharing.DAL.EntityNew.FriendshipRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestServiceNew/RemoveRequest", ReplyAction="http://tempuri.org/IFriendshipRequestServiceNew/RemoveRequestResponse")]
        void RemoveRequest(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestServiceNew/RemoveRequest", ReplyAction="http://tempuri.org/IFriendshipRequestServiceNew/RemoveRequestResponse")]
        System.Threading.Tasks.Task RemoveRequestAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFriendshipRequestServiceNewChannel : ImageSharing.FriendshipRequestServiceNew.IFriendshipRequestServiceNew, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FriendshipRequestServiceNewClient : System.ServiceModel.ClientBase<ImageSharing.FriendshipRequestServiceNew.IFriendshipRequestServiceNew>, ImageSharing.FriendshipRequestServiceNew.IFriendshipRequestServiceNew {
        
        public FriendshipRequestServiceNewClient() {
        }
        
        public FriendshipRequestServiceNewClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FriendshipRequestServiceNewClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FriendshipRequestServiceNewClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FriendshipRequestServiceNewClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ImageSharing.DAL.EntityNew.FriendshipRequest GetRequest(int id) {
            return base.Channel.GetRequest(id);
        }
        
        public System.Threading.Tasks.Task<ImageSharing.DAL.EntityNew.FriendshipRequest> GetRequestAsync(int id) {
            return base.Channel.GetRequestAsync(id);
        }
        
        public ImageSharing.DAL.EntityNew.FriendshipRequest[] GetRequests() {
            return base.Channel.GetRequests();
        }
        
        public System.Threading.Tasks.Task<ImageSharing.DAL.EntityNew.FriendshipRequest[]> GetRequestsAsync() {
            return base.Channel.GetRequestsAsync();
        }
        
        public void AddRequest(ImageSharing.DAL.EntityNew.FriendshipRequest request) {
            base.Channel.AddRequest(request);
        }
        
        public System.Threading.Tasks.Task AddRequestAsync(ImageSharing.DAL.EntityNew.FriendshipRequest request) {
            return base.Channel.AddRequestAsync(request);
        }
        
        public void RemoveRequest(int id) {
            base.Channel.RemoveRequest(id);
        }
        
        public System.Threading.Tasks.Task RemoveRequestAsync(int id) {
            return base.Channel.RemoveRequestAsync(id);
        }
    }
}