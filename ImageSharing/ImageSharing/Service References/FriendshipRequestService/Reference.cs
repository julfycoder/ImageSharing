﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImageSharing.FriendshipRequestService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FriendshipRequestService.IFriendshipRequestService")]
    public interface IFriendshipRequestService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestService/GetRequest", ReplyAction="http://tempuri.org/IFriendshipRequestService/GetRequestResponse")]
        ImageSharing.DAL.Entity.FriendshipRequest GetRequest(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestService/GetRequest", ReplyAction="http://tempuri.org/IFriendshipRequestService/GetRequestResponse")]
        System.Threading.Tasks.Task<ImageSharing.DAL.Entity.FriendshipRequest> GetRequestAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestService/GetRequests", ReplyAction="http://tempuri.org/IFriendshipRequestService/GetRequestsResponse")]
        ImageSharing.DAL.Entity.FriendshipRequest[] GetRequests();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestService/GetRequests", ReplyAction="http://tempuri.org/IFriendshipRequestService/GetRequestsResponse")]
        System.Threading.Tasks.Task<ImageSharing.DAL.Entity.FriendshipRequest[]> GetRequestsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestService/AddRequest", ReplyAction="http://tempuri.org/IFriendshipRequestService/AddRequestResponse")]
        void AddRequest(ImageSharing.DAL.Entity.FriendshipRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestService/AddRequest", ReplyAction="http://tempuri.org/IFriendshipRequestService/AddRequestResponse")]
        System.Threading.Tasks.Task AddRequestAsync(ImageSharing.DAL.Entity.FriendshipRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestService/RemoveRequest", ReplyAction="http://tempuri.org/IFriendshipRequestService/RemoveRequestResponse")]
        void RemoveRequest(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFriendshipRequestService/RemoveRequest", ReplyAction="http://tempuri.org/IFriendshipRequestService/RemoveRequestResponse")]
        System.Threading.Tasks.Task RemoveRequestAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFriendshipRequestServiceChannel : ImageSharing.FriendshipRequestService.IFriendshipRequestService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FriendshipRequestServiceClient : System.ServiceModel.ClientBase<ImageSharing.FriendshipRequestService.IFriendshipRequestService>, ImageSharing.FriendshipRequestService.IFriendshipRequestService {
        
        public FriendshipRequestServiceClient() {
        }
        
        public FriendshipRequestServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FriendshipRequestServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FriendshipRequestServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FriendshipRequestServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ImageSharing.DAL.Entity.FriendshipRequest GetRequest(int id) {
            return base.Channel.GetRequest(id);
        }
        
        public System.Threading.Tasks.Task<ImageSharing.DAL.Entity.FriendshipRequest> GetRequestAsync(int id) {
            return base.Channel.GetRequestAsync(id);
        }
        
        public ImageSharing.DAL.Entity.FriendshipRequest[] GetRequests() {
            return base.Channel.GetRequests();
        }
        
        public System.Threading.Tasks.Task<ImageSharing.DAL.Entity.FriendshipRequest[]> GetRequestsAsync() {
            return base.Channel.GetRequestsAsync();
        }
        
        public void AddRequest(ImageSharing.DAL.Entity.FriendshipRequest request) {
            base.Channel.AddRequest(request);
        }
        
        public System.Threading.Tasks.Task AddRequestAsync(ImageSharing.DAL.Entity.FriendshipRequest request) {
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
