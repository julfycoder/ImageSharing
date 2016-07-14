using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSharing.DAL.EntityNew
{
    public class Subscription : Entity
    {
        public int UserID { get; set; }
        public int FollowerID { get; set; }
        public DateTime DateTime { get; set; }
    }
}
