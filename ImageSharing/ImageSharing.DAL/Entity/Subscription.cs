using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSharing.DAL.Entity
{
    public class Subscription : Entity
    {
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
