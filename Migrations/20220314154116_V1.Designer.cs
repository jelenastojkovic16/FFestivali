﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace WEB_PROJEKAT.Migrations
{
    [DbContext(typeof(FilmskiFestivaliContext))]
    [Migration("20220314154116_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Models.DnevniRepertoar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("Cena")
                        .HasColumnType("real");

                    b.Property<string>("Dan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FestivalID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FestivalID");

                    b.ToTable("DnevniRepertoari");
                });

            modelBuilder.Entity("Models.Festival", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Grad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Kraj")
                        .HasColumnType("datetime2");

                    b.Property<string>("NazivFestivala")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Pocetak")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Festivali");
                });

            modelBuilder.Entity("Models.Film", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DanID")
                        .HasColumnType("int");

                    b.Property<string>("ImeReditelja")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NazivFilma")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Trajanje")
                        .HasColumnType("int");

                    b.Property<DateTime>("Vreme")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("DanID");

                    b.ToTable("Filmovi");
                });

            modelBuilder.Entity("Models.Karta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BrojUlaznica")
                        .HasColumnType("int");

                    b.Property<int?>("DanID")
                        .HasColumnType("int");

                    b.Property<int?>("RezervacijaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DanID");

                    b.HasIndex("RezervacijaID");

                    b.ToTable("Karte");
                });

            modelBuilder.Entity("Models.Rezervacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Ime")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prezime")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("UkupnaCena")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("Models.DnevniRepertoar", b =>
                {
                    b.HasOne("Models.Festival", "Festival")
                        .WithMany("DnevniRepertoari")
                        .HasForeignKey("FestivalID");

                    b.Navigation("Festival");
                });

            modelBuilder.Entity("Models.Film", b =>
                {
                    b.HasOne("Models.DnevniRepertoar", "Dan")
                        .WithMany("Filmovi")
                        .HasForeignKey("DanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dan");
                });

            modelBuilder.Entity("Models.Karta", b =>
                {
                    b.HasOne("Models.DnevniRepertoar", "Dan")
                        .WithMany("Karte")
                        .HasForeignKey("DanID");

                    b.HasOne("Models.Rezervacija", "Rezervacija")
                        .WithMany("Karte")
                        .HasForeignKey("RezervacijaID");

                    b.Navigation("Dan");

                    b.Navigation("Rezervacija");
                });

            modelBuilder.Entity("Models.DnevniRepertoar", b =>
                {
                    b.Navigation("Filmovi");

                    b.Navigation("Karte");
                });

            modelBuilder.Entity("Models.Festival", b =>
                {
                    b.Navigation("DnevniRepertoari");
                });

            modelBuilder.Entity("Models.Rezervacija", b =>
                {
                    b.Navigation("Karte");
                });
#pragma warning restore 612, 618
        }
    }
}
