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
        }

    }
}
