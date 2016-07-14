﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ImageSharing.DAL;
using ImageSharing.DAL.Entity;


namespace ImageSharing.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPostService" in both code and config file together.
    [ServiceContract]
    public interface IPostService
    {

        [OperationContract]
        void AddComment(int id, int commentId);

        [OperationContract]
        void RemoveComment(int id, int commentId);

        [OperationContract]
        void ChangeImagePath(int id, string photoPath);

        [OperationContract]
        void ChangeDataTime(int id, DateTime dateTime);

        [OperationContract]
        Post GetPost(int id);

        [OperationContract]
        IEnumerable<Post> GetPosts();

        [OperationContract]
        void AddPost(Post post);

        [OperationContract]
        void RemovePost(int id);

        [OperationContract]
        IEnumerable<Comment> GetComments(int id);

        [OperationContract]
        void ChangeDescription(int id, string text);
    }
}