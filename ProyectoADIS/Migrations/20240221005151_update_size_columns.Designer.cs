﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoADIS;

#nullable disable

namespace ProyectoADIS.Migrations
{
    [DbContext(typeof(AplicationDBContext))]
    [Migration("20240221005151_update_size_columns")]
    partial class update_size_columns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoADIS.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ProyectoADIS.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("CambioContrasena")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("varchar(18)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProyectoADIS.Models.Asignacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Asignacion");
                });

            modelBuilder.Entity("ProyectoADIS.Entities.Usuario", b =>
                {
                    b.HasOne("ProyectoADIS.Entities.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });
#pragma warning restore 612, 618
        }
    }
}
