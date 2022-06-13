using COFFEE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace COFFEE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Popust> Popust { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<Placanje> Placanje { get; set; }
        public DbSet<RedCekanja> RedCekanja { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<Izvjestaj> Izvjestaj { get; set; }
        public DbSet<ListaProizvoda> ListaProizvoda { get; set; }
        public DbSet<ListaNarudzbi> ListaNarudzbi { get; set; }
        public DbSet<OcjeneProizvoda> OcjeneProizvoda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<Popust>().ToTable("Popust");
            modelBuilder.Entity<Proizvod>().ToTable("Proizvod");
            modelBuilder.Entity<Placanje>().ToTable("Placanje");
            modelBuilder.Entity<RedCekanja>().ToTable("RedCekanja");
            modelBuilder.Entity<Narudzba>().ToTable("Narudzba");
            modelBuilder.Entity<Izvjestaj>().ToTable("Izvjestaj");
            modelBuilder.Entity<ListaProizvoda>().ToTable("ListaProizvoda");
            modelBuilder.Entity<ListaNarudzbi>().ToTable("ListaNarudzbi");
            modelBuilder.Entity<OcjeneProizvoda>().ToTable("OcjeneProizvoda");
            base.OnModelCreating(modelBuilder);
        }

    }
}
