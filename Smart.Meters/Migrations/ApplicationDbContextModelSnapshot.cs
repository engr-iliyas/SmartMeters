﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smart.Meters.Data;

#nullable disable

namespace Smart.Meters.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("Smart.Meters.Model.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TransformerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("TransformerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Smart.Meters.Model.F11KV", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("F33KVID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("F33KVID");

                    b.ToTable("F11KV");
                });

            modelBuilder.Entity("Smart.Meters.Model.F33KV", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("F33KV");
                });

            modelBuilder.Entity("Smart.Meters.Model.Meter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("InstallationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Seal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Meter");
                });

            modelBuilder.Entity("Smart.Meters.Model.Profile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApplicationLayerProtocol")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HDLC_Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LinkLayerProtocol")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MeterID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MeterRemoteMode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Port")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SimCardNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TransmissionMode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("MeterID")
                        .IsUnique();

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("Smart.Meters.Model.Reading", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<double>("ExpActiveEnergyT1")
                        .HasColumnType("REAL");

                    b.Property<double>("ExpActiveEnergyT2")
                        .HasColumnType("REAL");

                    b.Property<double>("ExpActiveEnergyT3")
                        .HasColumnType("REAL");

                    b.Property<double>("ExpActiveEnergyT4")
                        .HasColumnType("REAL");

                    b.Property<double>("ImpActiveEnergyT1")
                        .HasColumnType("REAL");

                    b.Property<double>("ImpActiveEnergyT2")
                        .HasColumnType("REAL");

                    b.Property<double>("ImpActiveEnergyT3")
                        .HasColumnType("REAL");

                    b.Property<double>("ImpActiveEnergyT4")
                        .HasColumnType("REAL");

                    b.Property<int>("MeterID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TotalExpActiveEnergy")
                        .HasColumnType("REAL");

                    b.Property<double>("TotalImpActiveEnergy")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.HasIndex("MeterID");

                    b.ToTable("Reading");
                });

            modelBuilder.Entity("Smart.Meters.Model.Transformer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("F11KVID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("F11KVID");

                    b.ToTable("Transformer");
                });

            modelBuilder.Entity("Smart.Meters.Model.Customer", b =>
                {
                    b.HasOne("Smart.Meters.Model.Transformer", null)
                        .WithMany("Customers")
                        .HasForeignKey("TransformerID");
                });

            modelBuilder.Entity("Smart.Meters.Model.F11KV", b =>
                {
                    b.HasOne("Smart.Meters.Model.F33KV", "F33KV")
                        .WithMany("Feeders")
                        .HasForeignKey("F33KVID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("F33KV");
                });

            modelBuilder.Entity("Smart.Meters.Model.Profile", b =>
                {
                    b.HasOne("Smart.Meters.Model.Meter", "Meter")
                        .WithOne("Profile")
                        .HasForeignKey("Smart.Meters.Model.Profile", "MeterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meter");
                });

            modelBuilder.Entity("Smart.Meters.Model.Reading", b =>
                {
                    b.HasOne("Smart.Meters.Model.Meter", "Meter")
                        .WithMany("Readings")
                        .HasForeignKey("MeterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meter");
                });

            modelBuilder.Entity("Smart.Meters.Model.Transformer", b =>
                {
                    b.HasOne("Smart.Meters.Model.F11KV", null)
                        .WithMany("Transformers")
                        .HasForeignKey("F11KVID");
                });

            modelBuilder.Entity("Smart.Meters.Model.F11KV", b =>
                {
                    b.Navigation("Transformers");
                });

            modelBuilder.Entity("Smart.Meters.Model.F33KV", b =>
                {
                    b.Navigation("Feeders");
                });

            modelBuilder.Entity("Smart.Meters.Model.Meter", b =>
                {
                    b.Navigation("Profile");

                    b.Navigation("Readings");
                });

            modelBuilder.Entity("Smart.Meters.Model.Transformer", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}