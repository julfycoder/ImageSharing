using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ImageSharing.DAL.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ImageSharing.DAL
{
    class ImageSharingContext : DbContext
    {
        public ImageSharingContext()
            : base("ImageSharingConnection")
        { }
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Tape> Tapes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<FriendshipRequest> FriendshipRequests { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<FriendshipRequest>()
               .HasRequired(f => f.Asker);
               //.WithRequiredDependent()
               //.WillCascadeOnDelete(false);

            modelBuilder.Entity<FriendshipRequest>()
               .HasRequired(f => f.Destination);
               //.WithRequiredDependent()
               //.WillCascadeOnDelete(false);
        }
    }
}
