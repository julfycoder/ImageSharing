﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImageSharing.CommentServiceNew {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CommentServiceNew.ICommentServiceNew")]
    public interface ICommentServiceNew {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommentServiceNew/ChangeText", ReplyAction="http://tempuri.org/ICommentServiceNew/ChangeTextResponse")]
        void ChangeText(int id, string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommentServiceNew/ChangeText", ReplyAction="http://tempuri.org/ICommentServiceNew/ChangeTextResponse")]
        System.Threading.Tasks.Task ChangeTextAsync(int id, string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommentServiceNew/GetComment", ReplyAction="http://tempuri.org/ICommentServiceNew/GetCommentResponse")]
        ImageSharing.DAL.EntityNew.Comment GetComment(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommentServiceNew/GetComment", ReplyAction="http://tempuri.org/ICommentServiceNew/GetCommentResponse")]
        System.Threading.Tasks.Task<ImageSharing.DAL.EntityNew.Comment> GetCommentAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommentServiceNew/GetComments", ReplyAction="http://tempuri.org/ICommentServiceNew/GetCommentsResponse")]
        ImageSharing.DAL.EntityNew.Comment[] GetComments();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommentServiceNew/GetComments", ReplyAction="http://tempuri.org/ICommentServiceNew/GetCommentsResponse")]
        System.Threading.Tasks.Task<ImageSharing.DAL.EntityNew.Comment[]> GetCommentsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommentServiceNew/AddComment", ReplyAction="http://tempuri.org/ICommentServiceNew/AddCommentResponse")]
        void AddComment(ImageSharing.DAL.EntityNew.Comment comment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommentServiceNew/AddComment", ReplyAction="http://tempuri.org/ICommentServiceNew/AddCommentResponse")]
        System.Threading.Tasks.Task AddCommentAsync(ImageSharing.DAL.EntityNew.Comment comment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommentServiceNew/RemoveComment", ReplyAction="http://tempuri.org/ICommentServiceNew/RemoveCommentResponse")]
        void RemoveComment(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommentServiceNew/RemoveComment", ReplyAction="http://tempuri.org/ICommentServiceNew/RemoveCommentResponse")]
        System.Threading.Tasks.Task RemoveCommentAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICommentServiceNewChannel : ImageSharing.CommentServiceNew.ICommentServiceNew, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CommentServiceNewClient : System.ServiceModel.ClientBase<ImageSharing.CommentServiceNew.ICommentServiceNew>, ImageSharing.CommentServiceNew.ICommentServiceNew {
        
        public CommentServiceNewClient() {
        }
        
        public CommentServiceNewClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CommentServiceNewClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommentServiceNewClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommentServiceNewClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void ChangeText(int id, string text) {
            base.Channel.ChangeText(id, text);
        }
        
        public System.Threading.Tasks.Task ChangeTextAsync(int id, string text) {
            return base.Channel.ChangeTextAsync(id, text);
        }
        
        public ImageSharing.DAL.EntityNew.Comment GetComment(int id) {
            return base.Channel.GetComment(id);
        }
        
        public System.Threading.Tasks.Task<ImageSharing.DAL.EntityNew.Comment> GetCommentAsync(int id) {
            return base.Channel.GetCommentAsync(id);
        }
        
        public ImageSharing.DAL.EntityNew.Comment[] GetComments() {
            return base.Channel.GetComments();
        }
        
        public System.Threading.Tasks.Task<ImageSharing.DAL.EntityNew.Comment[]> GetCommentsAsync() {
            return base.Channel.GetCommentsAsync();
        }
        
        public void AddComment(ImageSharing.DAL.EntityNew.Comment comment) {
            base.Channel.AddComment(comment);
        }
        
        public System.Threading.Tasks.Task AddCommentAsync(ImageSharing.DAL.EntityNew.Comment comment) {
            return base.Channel.AddCommentAsync(comment);
        }
        
        public void RemoveComment(int id) {
            base.Channel.RemoveComment(id);
        }
        
        public System.Threading.Tasks.Task RemoveCommentAsync(int id) {
            return base.Channel.RemoveCommentAsync(id);
        }
    }
}