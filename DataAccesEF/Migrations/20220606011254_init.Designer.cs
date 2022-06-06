﻿// <auto-generated />
using System;
using DataAccesEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccesEF.Migrations
{
    [DbContext(typeof(VivieroContext))]
    [Migration("20220606011254_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Compras", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CostoTotal")
                        .HasColumnType("float");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdItemPlanta")
                        .HasColumnType("int");

                    b.Property<int?>("ItemPlantasIdItemPlanta")
                        .HasColumnType("int");

                    b.HasKey("IdCompra");

                    b.HasIndex("ItemPlantasIdItemPlanta");

                    b.ToTable("Compras");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Compras");
                });

            modelBuilder.Entity("Dominio.FichaCuidados", b =>
                {
                    b.Property<int>("IdFichaCuidados")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdTipoIluminacion")
                        .HasColumnType("int");

                    b.Property<int?>("PlantaIdPlanta")
                        .HasColumnType("int");

                    b.Property<string>("Riego")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Temperatura")
                        .HasColumnType("int");

                    b.Property<int>("TipoIluminacionIdIluminacion")
                        .HasColumnType("int");

                    b.HasKey("IdFichaCuidados");

                    b.HasIndex("PlantaIdPlanta");

                    b.HasIndex("TipoIluminacionIdIluminacion");

                    b.ToTable("FichaCuidados");
                });

            modelBuilder.Entity("Dominio.Foto", b =>
                {
                    b.Property<int>("IdFoto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Imagen")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlantaIdPlanta")
                        .HasColumnType("int");

                    b.HasKey("IdFoto");

                    b.HasIndex("PlantaIdPlanta");

                    b.ToTable("Fotos");
                });

            modelBuilder.Entity("Dominio.ItemPlantas", b =>
                {
                    b.Property<int>("IdItemPlanta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("ComprasIdCompra")
                        .HasColumnType("int");

                    b.Property<int>("IdCompra")
                        .HasColumnType("int");

                    b.Property<int>("IdPlanta")
                        .HasColumnType("int");

                    b.Property<int?>("PlantaCompradaIdPlanta")
                        .HasColumnType("int");

                    b.Property<double>("PrecioUnitario")
                        .HasColumnType("float");

                    b.HasKey("IdItemPlanta");

                    b.HasIndex("ComprasIdCompra");

                    b.HasIndex("PlantaCompradaIdPlanta");

                    b.ToTable("ItemPlantas");
                });

            modelBuilder.Entity("Dominio.ParamSistema", b =>
                {
                    b.Property<int>("IdParam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValorMax")
                        .HasColumnType("int");

                    b.Property<int>("ValorMin")
                        .HasColumnType("int");

                    b.HasKey("IdParam");

                    b.ToTable("ParamSistema");
                });

            modelBuilder.Entity("Dominio.Planta", b =>
                {
                    b.Property<int>("IdPlanta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Altura")
                        .HasColumnType("int");

                    b.Property<string>("Ambiente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ComprasIdCompra")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FichaCuidadosIdFichaCuidados")
                        .HasColumnType("int");

                    b.Property<int>("IdFichaCuidados")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPlanta")
                        .HasColumnType("int");

                    b.Property<string>("NombreCientifico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombresVulgares")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoPlantaIdTipoPlanta")
                        .HasColumnType("int");

                    b.HasKey("IdPlanta");

                    b.HasIndex("ComprasIdCompra");

                    b.HasIndex("FichaCuidadosIdFichaCuidados");

                    b.HasIndex("TipoPlantaIdTipoPlanta");

                    b.ToTable("Plantas");
                });

            modelBuilder.Entity("Dominio.TipoIluminacion", b =>
                {
                    b.Property<int>("IdIluminacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionTipoIlum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdIluminacion");

                    b.ToTable("TipoIluminacions");
                });

            modelBuilder.Entity("Dominio.TipoPlanta", b =>
                {
                    b.Property<int>("IdTipoPlanta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PlantaIdPlanta")
                        .HasColumnType("int");

                    b.Property<string>("TipoDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoPlanta");

                    b.HasIndex("PlantaIdPlanta");

                    b.ToTable("TipoPlantas");
                });

            modelBuilder.Entity("Dominio.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Dominio.DePlaza", b =>
                {
                    b.HasBaseType("Dominio.Compras");

                    b.Property<double>("CostoFlete")
                        .HasColumnType("float");

                    b.Property<int>("IdPlanta")
                        .HasColumnType("int");

                    b.Property<int?>("PlantaIdPlanta")
                        .HasColumnType("int");

                    b.HasIndex("PlantaIdPlanta");

                    b.HasDiscriminator().HasValue("DePlaza");
                });

            modelBuilder.Entity("Dominio.Importadas", b =>
                {
                    b.HasBaseType("Dominio.Compras");

                    b.Property<bool>("EsDelSur")
                        .HasColumnType("bit");

                    b.Property<int>("IdPlanta")
                        .HasColumnName("Importadas_IdPlanta")
                        .HasColumnType("int");

                    b.Property<int?>("PlantaIdPlanta")
                        .HasColumnName("Importadas_PlantaIdPlanta")
                        .HasColumnType("int");

                    b.Property<int>("TasaDescuento")
                        .HasColumnType("int");

                    b.HasIndex("PlantaIdPlanta");

                    b.HasDiscriminator().HasValue("Importadas");
                });

            modelBuilder.Entity("Dominio.Compras", b =>
                {
                    b.HasOne("Dominio.ItemPlantas", "ItemPlantas")
                        .WithMany()
                        .HasForeignKey("ItemPlantasIdItemPlanta");
                });

            modelBuilder.Entity("Dominio.FichaCuidados", b =>
                {
                    b.HasOne("Dominio.Planta", null)
                        .WithMany("ListaFichas")
                        .HasForeignKey("PlantaIdPlanta");

                    b.HasOne("Dominio.TipoIluminacion", "TipoIluminacion")
                        .WithMany()
                        .HasForeignKey("TipoIluminacionIdIluminacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Foto", b =>
                {
                    b.HasOne("Dominio.Planta", null)
                        .WithMany("ListaFotos")
                        .HasForeignKey("PlantaIdPlanta");
                });

            modelBuilder.Entity("Dominio.ItemPlantas", b =>
                {
                    b.HasOne("Dominio.Compras", null)
                        .WithMany("Items")
                        .HasForeignKey("ComprasIdCompra");

                    b.HasOne("Dominio.Planta", "PlantaComprada")
                        .WithMany()
                        .HasForeignKey("PlantaCompradaIdPlanta");
                });

            modelBuilder.Entity("Dominio.Planta", b =>
                {
                    b.HasOne("Dominio.Compras", null)
                        .WithMany("ListaPlantas")
                        .HasForeignKey("ComprasIdCompra");

                    b.HasOne("Dominio.FichaCuidados", "FichaCuidados")
                        .WithMany()
                        .HasForeignKey("FichaCuidadosIdFichaCuidados");

                    b.HasOne("Dominio.TipoPlanta", "TipoPlanta")
                        .WithMany()
                        .HasForeignKey("TipoPlantaIdTipoPlanta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.TipoPlanta", b =>
                {
                    b.HasOne("Dominio.Planta", null)
                        .WithMany("ListaTipoPlantas")
                        .HasForeignKey("PlantaIdPlanta");
                });

            modelBuilder.Entity("Dominio.DePlaza", b =>
                {
                    b.HasOne("Dominio.Planta", "Planta")
                        .WithMany()
                        .HasForeignKey("PlantaIdPlanta");
                });

            modelBuilder.Entity("Dominio.Importadas", b =>
                {
                    b.HasOne("Dominio.Planta", "Planta")
                        .WithMany()
                        .HasForeignKey("PlantaIdPlanta");
                });
#pragma warning restore 612, 618
        }
    }
}
