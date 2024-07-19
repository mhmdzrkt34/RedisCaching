﻿using ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiService.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {



        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> cars { get; set; }
    }
}
