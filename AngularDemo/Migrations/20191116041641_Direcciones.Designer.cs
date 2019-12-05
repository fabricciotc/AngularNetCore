﻿// <auto-generated />
using System;
using AngularDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AngularDemo.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20191116041641_Direcciones")]
    partial class Direcciones
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AngularDemo.Models.Direccione", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Calle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonaID")
                        .HasColumnType("int");

                    b.Property<string>("Provincia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("PersonaID");

                    b.ToTable("Direccione");
                });

            modelBuilder.Entity("AngularDemo.Models.Persona", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("AngularDemo.Models.Direccione", b =>
                {
                    b.HasOne("AngularDemo.Models.Persona", "Persona")
                        .WithMany("Direcciones")
                        .HasForeignKey("PersonaID");
                });
#pragma warning restore 612, 618
        }
    }
}
