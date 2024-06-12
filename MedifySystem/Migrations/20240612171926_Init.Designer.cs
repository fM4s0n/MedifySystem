﻿// <auto-generated />
using System;
using MedifySystem.MedifyCommon.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedifySystem.Migrations
{
    [DbContext(typeof(MedifyDatabaseContext))]
    [Migration("20240612171926_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("MedifySystem.MedifyCommon.Models.Appointment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<string>("HospitalOfficialId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("PatientAttended")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("MedifySystem.MedifyCommon.Models.Patient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GPName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NHSNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Patients", (string)null);
                });

            modelBuilder.Entity("MedifySystem.MedifyCommon.Models.PatientAdmittance", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdmittanceReason")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DischargeReason")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HospitalOfficialId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientAdmittances", (string)null);
                });

            modelBuilder.Entity("MedifySystem.MedifyCommon.Models.PatientRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdmittanceId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PatientRecords", (string)null);
                });

            modelBuilder.Entity("MedifySystem.MedifyCommon.Models.PatientRecordDataEntry", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientRecordId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PatientRecordId");

                    b.ToTable("PatientRecordDataEntries", (string)null);
                });

            modelBuilder.Entity("MedifySystem.MedifyCommon.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("RequiresPasswordReset")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("MedifySystem.MedifyCommon.Models.PatientAdmittance", b =>
                {
                    b.HasOne("MedifySystem.MedifyCommon.Models.Patient", null)
                        .WithMany("Admittances")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedifySystem.MedifyCommon.Models.PatientRecordDataEntry", b =>
                {
                    b.HasOne("MedifySystem.MedifyCommon.Models.PatientRecord", null)
                        .WithMany("DataEntries")
                        .HasForeignKey("PatientRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedifySystem.MedifyCommon.Models.Patient", b =>
                {
                    b.Navigation("Admittances");
                });

            modelBuilder.Entity("MedifySystem.MedifyCommon.Models.PatientRecord", b =>
                {
                    b.Navigation("DataEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
