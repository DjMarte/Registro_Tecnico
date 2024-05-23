﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registro_Tecnico.DAL;

#nullable disable

namespace Registro_Tecnico.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Registro_Tecnico.Models.Tecnicos", b =>
                {
                    b.Property<int>("TecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SueldoHora")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TecnicoId");

                    b.HasIndex("TipoId");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("Registro_Tecnico.Models.TiposTecnicos", b =>
                {
                    b.Property<int>("TipoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TipoId");

                    b.ToTable("TiposTecnicos");
                });

            modelBuilder.Entity("Registro_Tecnico.Models.Tecnicos", b =>
                {
                    b.HasOne("Registro_Tecnico.Models.TiposTecnicos", "TiposTecnicos")
                        .WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TiposTecnicos");
                });
#pragma warning restore 612, 618
        }
    }
}