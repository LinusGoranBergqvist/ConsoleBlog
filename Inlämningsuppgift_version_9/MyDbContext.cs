using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Inlämningsuppgift_version_9;
using static System.Net.Mime.MediaTypeNames;

namespace Inlämningsuppgift_version_9
{
    internal class MyDbContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }

        string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Inlämningsuppgift_version_9;Trusted_Connection=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost { Id = 1, Title = "Tacos", Text = "Tacos innehåller en del saker så som köttfärs, gurka och salsa" },
                new BlogPost { Id = 2, Title = "DeggDjur", Text = "DeggDjur är ett djur som inte lägger ägg utan redan levande barn" },
                new BlogPost { Id = 3, Title = "Filmer", Text = "Det fiins många filmer att  njuta av " },
                new BlogPost { Id = 4, Title = "Haven", Text = "Haven är fyllda med skräp och tar död på allt liv" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Djur" },
                new Category { Id = 2, Name = "Mat" },
                new Category { Id = 3, Name = "Natur" },
                new Category { Id = 4, Name = "Aktiviteter" }
            ) ;
        }
    }
}
