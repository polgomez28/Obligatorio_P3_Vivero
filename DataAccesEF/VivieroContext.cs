using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccesEF
{
    public class VivieroContext : DbContext
    {
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<TipoPlanta> TipoPlantas { get; set; }
        public DbSet<FichaCuidados> FichaCuidados { get; set; }
        public DbSet<ParamSistema> ParamSistema { get; set; }
        public DbSet<TipoIluminacion> TipoIluminacions { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<DePlaza> DePlazas { get; set; }
        public DbSet<Importadas> Importadas { get; set; }
        public DbSet<ItemPlantas> ItemPlantas { get; set; }


        public VivieroContext(DbContextOptions<VivieroContext> options) :
            base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = (new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Connection_Vivero"));
            //optionsBuilder.UseSqlServer("SERVER=.\\SQLEXPRESS; database=ViveroEF; Integrated Security = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            // Creo la tabla Fotos
            modelBuilder.Entity<Foto>();
            // Creo la tabla TipoPlantas
            modelBuilder.Entity<TipoPlanta>();
            // Creo la tabla TipoIluminacion
            modelBuilder.Entity<TipoIluminacion>();
            // Creo la tabla FichaCuidados
            modelBuilder.Entity<FichaCuidados>();
            //Creo la relación
            modelBuilder.Entity<FichaCuidados>().HasOne(f => f.TipoIluminacion);
            // Creo la tabla ParamSistema
            modelBuilder.Entity<ParamSistema>();
            // Creo la tabla Usuarios
            modelBuilder.Entity<Usuario>();
            // Creo la tabla ItemPlantas
            modelBuilder.Entity<ItemPlantas>();
            // Creo la tabla Compras
            modelBuilder.Entity<Compras>();
            // Creamos realción
            modelBuilder.Entity<Compras>().HasOne(c => c.ItemPlantas);
            // Creo la tabla Plantas
            modelBuilder.Entity<Planta>();
            // Creamos realción
            modelBuilder.Entity<Planta>().HasOne(p => p.FichaCuidados);
            // Creamos realción
            modelBuilder.Entity<Planta>().HasOne(p => p.TipoPlanta);
            // Creo la tabla DePlaza
            modelBuilder.Entity<DePlaza>();
            // Creamos realción
            modelBuilder.Entity<DePlaza>().HasOne(d => d.Planta);
            // Creo la tabla Importadas
            modelBuilder.Entity<Importadas>();
            // Creamos realción
            modelBuilder.Entity<Importadas>().HasOne(i => i.Planta);




        }
    }
}
