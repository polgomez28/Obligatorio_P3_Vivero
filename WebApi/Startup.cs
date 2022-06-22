using DataAccesEF;
using Dominio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<IRepositorioPlanta, RepositorioPlantaEF>();
            services.AddScoped<IRepositorioParamSistema, RepositorioParamSistemaEF>();
            services.AddScoped<IRepositorioTipoPlanta, RepositorioTipoPlantaEF>();
            services.AddScoped<IRepositorioCompras, RepositorioComprasEF>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuariosEF>();
            services.AddScoped<IRepositorioDePlaza, RepositorioDePlazaEF>();

            services.AddDbContext<ViveroContext>
                (opciones => opciones
                             .UseSqlServer(Configuration.GetConnectionString("Connection_Vivero"))
                             .EnableSensitiveDataLogging());
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
