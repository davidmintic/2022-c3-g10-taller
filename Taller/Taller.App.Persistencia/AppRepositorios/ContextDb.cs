using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio;

namespace Taller.App.Persistencia
{
    public class ContextDb : DbContext
    {

        public DbSet<Mecanico> Mechanics { get; set; }
        public DbSet<Revision> Revisiones { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:server-tallertic.database.windows.net,1433;Initial Catalog=bd_tallertic;Persist Security Info=False;User ID=admintaller;Password=tallerTic2020#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Revision>()
                .HasOne(p => p.Vehiculo)
                .WithOne(b => b.Revision)
                .HasForeignKey<Revision>(b => b.VehiculoId);

            // modelBuilder.Entity<Mecanico>()
            // .Property(f => f.MecanicoId)
            // .ValueGeneratedOnAdd();
        }

    }
}