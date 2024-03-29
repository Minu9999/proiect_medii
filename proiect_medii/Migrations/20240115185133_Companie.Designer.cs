﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proiect_medii.Data;

#nullable disable

namespace proiect_medii.Migrations
{
    [DbContext(typeof(proiect_mediiContext))]
    [Migration("20240115185133_Companie")]
    partial class Companie
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("proiect_medii.Models.Companie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume_companie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Companie");
                });

            modelBuilder.Entity("proiect_medii.Models.Terminal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume_terminal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Terminal");
                });

            modelBuilder.Entity("proiect_medii.Models.Zbor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CompanieID")
                        .HasColumnType("int");

                    b.Property<string>("Companie_Aeriana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data_zbor")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destinatie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.HasIndex("CompanieID");

                    b.ToTable("Zbor");
                });

            modelBuilder.Entity("proiect_medii.Models.ZborTerminal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("TerminalID")
                        .HasColumnType("int");

                    b.Property<int>("ZborID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TerminalID");

                    b.HasIndex("ZborID");

                    b.ToTable("ZborTerminal");
                });

            modelBuilder.Entity("proiect_medii.Models.Zbor", b =>
                {
                    b.HasOne("proiect_medii.Models.Companie", "Companie")
                        .WithMany("Zboruri")
                        .HasForeignKey("CompanieID");

                    b.Navigation("Companie");
                });

            modelBuilder.Entity("proiect_medii.Models.ZborTerminal", b =>
                {
                    b.HasOne("proiect_medii.Models.Terminal", "Terminal")
                        .WithMany("ZborTerminale")
                        .HasForeignKey("TerminalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("proiect_medii.Models.Zbor", "Zbor")
                        .WithMany("ZborTerminale")
                        .HasForeignKey("ZborID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Terminal");

                    b.Navigation("Zbor");
                });

            modelBuilder.Entity("proiect_medii.Models.Companie", b =>
                {
                    b.Navigation("Zboruri");
                });

            modelBuilder.Entity("proiect_medii.Models.Terminal", b =>
                {
                    b.Navigation("ZborTerminale");
                });

            modelBuilder.Entity("proiect_medii.Models.Zbor", b =>
                {
                    b.Navigation("ZborTerminale");
                });
#pragma warning restore 612, 618
        }
    }
}
