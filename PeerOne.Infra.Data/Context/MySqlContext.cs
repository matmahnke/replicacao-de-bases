using Microsoft.EntityFrameworkCore;
using PeerOne.Domain.Entities;
using PeerOne.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Text;

namespace PeerOne.Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql("Server=localhost;DataBase=PeerOne;Uid=root;Pwd=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMapping().Configure);
        }
    }
}
