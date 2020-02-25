using IRunes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=XTRELLS-PC\SQLEXPRESS;Database=IRunesDb;Integrated Security=true;");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Tracks> Tracks { get; set; }

        public DbSet<Albums> Albums { get; set; }
    }
}
