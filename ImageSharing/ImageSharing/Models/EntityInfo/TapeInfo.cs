using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageSharing.Models.EntityInfo
{
    public class TapeInfo:EntityInfoBase
    {
        public List<PostInfo> Posts { get; set; }
    }
}