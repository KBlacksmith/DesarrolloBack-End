﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_Peliculas;

#nullable disable

namespace WebAPI_Peliculas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220917035838_PeliculaActor")]
    partial class PeliculaActor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebAPI_Peliculas.Entidades.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PeliculaId");

                    b.ToTable("Actores");
                });

            modelBuilder.Entity("WebAPI_Peliculas.Entidades.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("WebAPI_Peliculas.Entidades.Actor", b =>
                {
                    b.HasOne("WebAPI_Peliculas.Entidades.Pelicula", "Peliculas")
                        .WithMany("Cast")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("WebAPI_Peliculas.Entidades.Pelicula", b =>
                {
                    b.Navigation("Cast");
                });
#pragma warning restore 612, 618
        }
    }
}
