﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pharmacy.Models;

namespace Pharmacy.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20220620134449_changedName")]
    partial class changedName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pharmacy.Models.Medicine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("countryProducer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("Pharmacy.Models.Pharmacy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pharmacy");
                });

            modelBuilder.Entity("Pharmacy.Models.Prescription", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Doctor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("Pharmacy.Models.PrescriptionMedicine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<long?>("MedicineId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PrescriptionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("PrescriptionMedicine");
                });

            modelBuilder.Entity("Pharmacy.Models.Procurement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<long?>("MedicineId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PharmacyId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("PharmacyId");

                    b.ToTable("Procurement");
                });

            modelBuilder.Entity("Pharmacy.Models.PrescriptionMedicine", b =>
                {
                    b.HasOne("Pharmacy.Models.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId");

                    b.HasOne("Pharmacy.Models.Prescription", "Prescription")
                        .WithMany()
                        .HasForeignKey("PrescriptionId");

                    b.Navigation("Medicine");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Pharmacy.Models.Procurement", b =>
                {
                    b.HasOne("Pharmacy.Models.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId");

                    b.HasOne("Pharmacy.Models.Pharmacy", "Pharmacy")
                        .WithMany()
                        .HasForeignKey("PharmacyId");

                    b.Navigation("Medicine");

                    b.Navigation("Pharmacy");
                });
#pragma warning restore 612, 618
        }
    }
}
