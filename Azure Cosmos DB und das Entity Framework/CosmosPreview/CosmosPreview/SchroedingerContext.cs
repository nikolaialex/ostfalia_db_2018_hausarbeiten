using CosmosPreview.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosPreview
{

    class SchroedingerContext : DbContext
    {
        /// <summary>
        /// Repräsentiert alle Box-Entitäten innerhalb des Context
        /// </summary>
        public DbSet<Box> Boxes { get; set; }

        /// <summary>
        /// Repräsentiert alle Cat-Entitäten innerhalb des Context
        /// </summary>
        public DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // Hier wird der Datenspeicher des Context definiert.
            // Häufig sieht das so aus:
            //optionsBuilder.UseSqlServer("");

            // Der Connection-String wird innerhlab von Azure Comos DB-Emulator angezeigt.
            optionsBuilder.UseCosmos(
              "https://localhost:8081",
              "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
              "schroedinger");
        }

        /// <summary>
        /// Wird während der Initialisierung aufgerufen. In diesem Bereich können mit
        /// Hilfe der Fluent-API Abhängigkeiten definiert werden.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Beispiel zur Modelierung einer Abhängigkeit
            //builder.Entity<Box>()
            //    .HasOne<Cat>()
            //    .WithOne(e => e.Box);
        }



    }
}
