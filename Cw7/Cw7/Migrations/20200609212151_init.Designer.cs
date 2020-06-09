﻿// <auto-generated />
using System;
using Cw7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cw7.Migrations
{
    [DbContext(typeof(OrdersContext))]
    [Migration("20200609212151_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cw7.Models.Klient", b =>
                {
                    b.Property<int>("IdKlient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("IdKlient");

                    b.ToTable("Klient");
                });

            modelBuilder.Entity("Cw7.Models.Pracownik", b =>
                {
                    b.Property<int>("IdPracownik")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("IdPracownik");

                    b.ToTable("Pracownicy");
                });

            modelBuilder.Entity("Cw7.Models.WyrobCukierniczy", b =>
                {
                    b.Property<int>("IdWyrobuCukierniczego")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("CenaZaSzt")
                        .HasColumnType("real");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Typ")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("IdWyrobuCukierniczego");

                    b.ToTable("WyrobCukierniczy");
                });

            modelBuilder.Entity("Cw7.Models.Zamowienie", b =>
                {
                    b.Property<int>("IdKlient")
                        .HasColumnType("int");

                    b.Property<int>("IdPracownik")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPrzyjecia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRealizacji")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdZamowienia")
                        .HasColumnType("int");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("IdKlient", "IdPracownik");

                    b.HasIndex("IdPracownik");

                    b.ToTable("Zamowienie");
                });

            modelBuilder.Entity("Cw7.Models.Zamowienie_WyrobCukierniczy", b =>
                {
                    b.Property<int>("IdWyrobuCukierniczego")
                        .HasColumnType("int");

                    b.Property<int>("IdZamowienia")
                        .HasColumnType("int");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int?>("WyrobCukierniczyIdWyrobuCukierniczego")
                        .HasColumnType("int");

                    b.Property<int?>("ZamowienieIdKlient")
                        .HasColumnType("int");

                    b.Property<int?>("ZamowienieIdPracownik")
                        .HasColumnType("int");

                    b.HasKey("IdWyrobuCukierniczego", "IdZamowienia");

                    b.HasIndex("WyrobCukierniczyIdWyrobuCukierniczego");

                    b.HasIndex("ZamowienieIdKlient", "ZamowienieIdPracownik");

                    b.ToTable("Zamowienie_WyrobCukierniczy");
                });

            modelBuilder.Entity("Cw7.Models.Zamowienie", b =>
                {
                    b.HasOne("Cw7.Models.Klient", "Klient")
                        .WithMany("Zamowienia")
                        .HasForeignKey("IdKlient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cw7.Models.Pracownik", "Pracownik")
                        .WithMany("Zamowienia")
                        .HasForeignKey("IdPracownik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cw7.Models.Zamowienie_WyrobCukierniczy", b =>
                {
                    b.HasOne("Cw7.Models.WyrobCukierniczy", "WyrobCukierniczy")
                        .WithMany("Zam_WyrobCuier")
                        .HasForeignKey("WyrobCukierniczyIdWyrobuCukierniczego");

                    b.HasOne("Cw7.Models.Zamowienie", "Zamowienie")
                        .WithMany()
                        .HasForeignKey("ZamowienieIdKlient", "ZamowienieIdPracownik");
                });
#pragma warning restore 612, 618
        }
    }
}
