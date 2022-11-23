﻿// <auto-generated />
using System;
using API_invvideojuegos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIinvvideojuegos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220929035239_juegos100")]
    partial class juegos100
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc.1.22426.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_invvideojuegos.Entidades.Juegos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("clasificacion")
                        .HasColumnType("int");

                    b.Property<string>("desarrolladora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("precio")
                        .HasColumnType("int");

                    b.Property<int?>("videojuegosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("videojuegosId");

                    b.ToTable("Juego");
                });

            modelBuilder.Entity("API_invvideojuegos.Entidades.videojuegos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Videojuegos");
                });

            modelBuilder.Entity("API_invvideojuegos.Entidades.Juegos", b =>
                {
                    b.HasOne("API_invvideojuegos.Entidades.videojuegos", null)
                        .WithMany("Juegos")
                        .HasForeignKey("videojuegosId");
                });

            modelBuilder.Entity("API_invvideojuegos.Entidades.videojuegos", b =>
                {
                    b.Navigation("Juegos");
                });
#pragma warning restore 612, 618
        }
    }
}
