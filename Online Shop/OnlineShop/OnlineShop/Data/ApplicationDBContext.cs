using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Categorie> Categorii { get; set; }
        public DbSet<Subcategorie> Subcategorii { get; set; }
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Promotie_Produs> Promotii_Produse { get; set; }
        public DbSet<Promotie> Promotii { get; set; }
        public DbSet<Utilizator> Utilizatori { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Promotie_Produs>()
                .HasKey(c => new { c.Id_Produs, c.Id_promotie });
        }
    }
}
