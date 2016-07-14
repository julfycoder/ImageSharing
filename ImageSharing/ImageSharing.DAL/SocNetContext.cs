using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ImageSharing.DAL.Entity;

namespace ImageSharing.DAL
{
    public class SocNetContext : DbContext
    {
        public SocNetContext()
            : base("SocNetConnection")
        { }
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Tape> Tapes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<FriendshipRequest> FriendshipRequests { get; set; }
    }
}
