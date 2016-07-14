using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageSharing.Models.EntityInfo
{
    public class PostAuthorInfo:EntityInfoBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AvatarPathInfo { get; set; }
    }
}