using Microsoft.EntityFrameworkCore;
using TR.Domain.Entities;
using TR.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace TR.Infra.Data.Context
{
    public class SqlContext : DbContext
    {

        string _connectionString;

        public SqlContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Detail> Details { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder
                   .UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<User>(new UserMap().Configure)
                .Entity<Detail>(new DetailMap().Configure);

        }
    }
}
