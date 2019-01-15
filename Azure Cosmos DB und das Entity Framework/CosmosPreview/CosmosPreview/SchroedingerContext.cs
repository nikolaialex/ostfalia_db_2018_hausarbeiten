using CosmosPreview.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosPreview
{
    class SchroedingerContext : DbContext
    {

        public DbSet<Box> Boxes { get; set; }
        public DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
              "https://localhost:8081",
              "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
              "schroedinger");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }



    }
}
