﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PavilionKyrpton.DatabaseConnection;

namespace PavilionKyrpton.Migrations
{
    [DbContext(typeof(DbConnection))]
    [Migration("20210503063129_CapacityContract")]
    partial class CapacityContract
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("PavilionKyrpton.Entities.CapacityContract", b =>
                {
                    b.Property<string>("CapacityContractId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BegTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Buy_Sell")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Infrastructure")
                        .HasColumnType("TEXT");

                    b.Property<string>("InfrastructureType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Network")
                        .HasColumnType("TEXT");

                    b.Property<string>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("PriceUnit")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("TEXT");

                    b.Property<string>("QuantityUnit")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceType")
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeZone")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TradeDate")
                        .HasColumnType("TEXT");

                    b.HasKey("CapacityContractId");

                    b.ToTable("CapacityContracts");
                });

            modelBuilder.Entity("PavilionKyrpton.Entities.EnagasFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CodigoAdenda")
                        .HasColumnType("TEXT");

                    b.Property<string>("CodigoContrato")
                        .HasColumnType("TEXT");

                    b.Property<string>("CodigoSubasta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comercializador")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContratoOrigen")
                        .HasColumnType("TEXT");

                    b.Property<string>("Coordinacion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Duracion_horas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Estado")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaFormalizacion")
                        .HasColumnType("TEXT");

                    b.Property<int>("FileId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FinContracto")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdOfertaTransaccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Infrastructura")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("InicioContracto")
                        .HasColumnType("TEXT");

                    b.Property<string>("MateriaPrima")
                        .HasColumnType("TEXT");

                    b.Property<string>("NaturalezaCapacidad")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroSolicitud")
                        .HasColumnType("TEXT");

                    b.Property<string>("Operador")
                        .HasColumnType("TEXT");

                    b.Property<string>("Origen")
                        .HasColumnType("TEXT");

                    b.Property<string>("Precio_Units")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio_Value")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prima_Units")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Prima_Value")
                        .HasColumnType("TEXT");

                    b.Property<string>("QFirmeContratada_Units")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("QFirmeContratada_Volume")
                        .HasColumnType("TEXT");

                    b.Property<string>("QIntContratada_Units")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("QIntContratada_Volume")
                        .HasColumnType("TEXT");

                    b.Property<string>("QTotalContratada_Units")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("QTotalContratada_Volume")
                        .HasColumnType("TEXT");

                    b.Property<string>("SentidoFlujo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Servicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoDuracion")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoInfrastructura")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoPeaje")
                        .HasColumnType("TEXT");

                    b.Property<string>("Transaccion")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.ToTable("EnagasFiles");
                });

            modelBuilder.Entity("PavilionKyrpton.Entities.FileClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileType")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoadResult")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LoadTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Records")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("PavilionKyrpton.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PavilionKyrpton.Entities.EnagasFile", b =>
                {
                    b.HasOne("PavilionKyrpton.Entities.FileClass", "File")
                        .WithMany("EnagasFiles")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");
                });

            modelBuilder.Entity("PavilionKyrpton.Entities.FileClass", b =>
                {
                    b.Navigation("EnagasFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
