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
    [DbContext(typeof(ViveroContext))]
    [Migration("20220622192156_init5")]
    partial class init5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CostoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Compras");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Compra");
                });

            modelBuilder.Entity("Dominio.FichaCuidados", b =>
                {
                    b.Property<int>("IdFichaCuidados")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdTipoIluminacion")
                        .HasColumnType("int");

                    b.Property<string>("Riego")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Temperatura")
                        .HasColumnType("int");

                    b.HasKey("IdFichaCuidados");

                    b.HasIndex("IdTipoIluminacion");

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

            modelBuilder.Entity("Dominio.ItemCompra", b =>
                {
                    b.Property<int>("IdCompra")
                        .HasColumnType("int");

                    b.Property<int>("IdPlanta")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdCompra", "IdPlanta");

                    b.HasIndex("IdPlanta");

                    b.ToTable("ItemCompras");
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

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdFichaCuidados")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPlanta")
                        .HasColumnType("int");

                    b.Property<string>("NombreCientifico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombresVulgares")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPlanta");

                    b.HasIndex("IdFichaCuidados");

                    b.HasIndex("IdTipoPlanta");

                    b.ToTable("Plantas");
                });

            modelBuilder.Entity("Dominio.TipoIluminacion", b =>
                {
                    b.Property<int>("IdIluminacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionTipoIlum")
                        .IsRequired()
                        .HasColumnName("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdIluminacion");

                    b.ToTable("TipoIluminacion");
                });

            modelBuilder.Entity("Dominio.TipoPlanta", b =>
                {
                    b.Property<int>("IdTipoPlanta")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoDesc")
                        .IsRequired()
                        .HasColumnName("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoNombre")
                        .IsRequired()
                        .HasColumnName("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoPlanta");

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
                    b.HasBaseType("Dominio.Compra");

                    b.Property<double>("CostoFlete")
                        .HasColumnType("float");

                    b.Property<int>("TasaIVA")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("DePlaza");
                });

            modelBuilder.Entity("Dominio.Importadas", b =>
                {
                    b.HasBaseType("Dominio.Compra");

                    b.Property<bool>("EsDelSur")
                        .HasColumnType("bit");

                    b.Property<int>("TasaDescuento")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Importadas");
                });

            modelBuilder.Entity("Dominio.FichaCuidados", b =>
                {
                    b.HasOne("Dominio.TipoIluminacion", "TipoIluminacion")
                        .WithMany()
                        .HasForeignKey("IdTipoIluminacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Foto", b =>
                {
                    b.HasOne("Dominio.Planta", null)
                        .WithMany("ListaFotos")
                        .HasForeignKey("PlantaIdPlanta");
                });

            modelBuilder.Entity("Dominio.ItemCompra", b =>
                {
                    b.HasOne("Dominio.Compra", "Compra")
                        .WithMany("Items")
                        .HasForeignKey("IdCompra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Planta", "Planta")
                        .WithMany("Items")
                        .HasForeignKey("IdPlanta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Planta", b =>
                {
                    b.HasOne("Dominio.FichaCuidados", "FichaCuidados")
                        .WithMany()
                        .HasForeignKey("IdFichaCuidados");

                    b.HasOne("Dominio.TipoPlanta", "TipoPlanta")
                        .WithMany()
                        .HasForeignKey("IdTipoPlanta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
