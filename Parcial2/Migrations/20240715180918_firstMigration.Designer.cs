﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parcial2.Context;

#nullable disable

namespace Parcial2.Migrations
{
    [DbContext(typeof(ContextDb))]
    [Migration("20240715180918_firstMigration")]
    partial class firstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Parcial2.Models.Albanile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Calle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodPost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Albanile");
                });

            modelBuilder.Entity("Parcial2.Models.AlbanilesXObra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdAlbanil")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdAlbanilNavigationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdObra")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdObraNavigationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TareaArealizar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdAlbanilNavigationId");

                    b.HasIndex("IdObraNavigationId");

                    b.ToTable("AlbanilesXObra");
                });

            modelBuilder.Entity("Parcial2.Models.Obra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DatosVarios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdTipoObra")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdTipoObraNavigationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoObraNavigationId");

                    b.ToTable("Obra");
                });

            modelBuilder.Entity("Parcial2.Models.TiposObra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposObras");
                });

            modelBuilder.Entity("Parcial2.Models.AlbanilesXObra", b =>
                {
                    b.HasOne("Parcial2.Models.Albanile", "IdAlbanilNavigation")
                        .WithMany("AlbanilesXObras")
                        .HasForeignKey("IdAlbanilNavigationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Parcial2.Models.Obra", "IdObraNavigation")
                        .WithMany("AlbanilesXObras")
                        .HasForeignKey("IdObraNavigationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdAlbanilNavigation");

                    b.Navigation("IdObraNavigation");
                });

            modelBuilder.Entity("Parcial2.Models.Obra", b =>
                {
                    b.HasOne("Parcial2.Models.TiposObra", "IdTipoObraNavigation")
                        .WithMany("Obras")
                        .HasForeignKey("IdTipoObraNavigationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdTipoObraNavigation");
                });

            modelBuilder.Entity("Parcial2.Models.Albanile", b =>
                {
                    b.Navigation("AlbanilesXObras");
                });

            modelBuilder.Entity("Parcial2.Models.Obra", b =>
                {
                    b.Navigation("AlbanilesXObras");
                });

            modelBuilder.Entity("Parcial2.Models.TiposObra", b =>
                {
                    b.Navigation("Obras");
                });
#pragma warning restore 612, 618
        }
    }
}
