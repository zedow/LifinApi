using LifinAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifinAPI.Data
{
    public class LifinContext : DbContext
    {
        public LifinContext(DbContextOptions<LifinContext> options) : base (options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Bde> Bdes { get; set; }
        public DbSet<Hype> Hypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Member (Bde to User relation)
            modelBuilder.Entity<Member>().HasKey(key => new { key.UserId, key.BdeId });
            modelBuilder.Entity<Member>().HasOne(pt => pt.User).WithMany(p => p.BdeMemberList).HasForeignKey(pt => pt.UserId);
            modelBuilder.Entity<Member>().HasOne(pt => pt.Bde).WithMany(p => p.Members).HasForeignKey(pt => pt.BdeId);

            // Follower (Bde to User relation (follow only))
            modelBuilder.Entity<Follower>().HasKey(key => new { key.UserId, key.BdeId });
            modelBuilder.Entity<Follower>().HasOne(pt => pt.User).WithMany(p => p.BdeFollowList).HasForeignKey(pt => pt.UserId);
            modelBuilder.Entity<Follower>().HasOne(pt => pt.Bde).WithMany(p => p.Followers).HasForeignKey(pt => pt.BdeId);

            // Hype (Event to User relation)
            modelBuilder.Entity<Hype>().HasKey(key => new { key.UserId, key.EventId });
            modelBuilder.Entity<Hype>().HasOne(pt => pt.User).WithMany(p => p.Hypes).HasForeignKey(pt => pt.UserId);
            modelBuilder.Entity<Hype>().HasOne(pt => pt.Event).WithMany(p => p.Hypes).HasForeignKey(pt => pt.EventId);

            // Events to Bde relation
            modelBuilder.Entity<Event>().HasOne(pt => pt.Bde).WithMany(p => p.Events).HasForeignKey(pt => pt.BdeId);
            modelBuilder.Entity<Bde>().HasMany(pt => pt.Events).WithOne(p => p.Bde);

            // Bde to User as Owner relation
            modelBuilder.Entity<Bde>().HasOne(bd => bd.Owner).WithMany(user => user.OwnerBdeList).HasForeignKey(bd => bd.OwnerId);
        }
    }
}
