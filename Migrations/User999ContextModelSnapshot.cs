﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Курсовая_работа2.Context;

#nullable disable

namespace Курсовая_работа2.Migrations
{
    [DbContext(typeof(User999Context))]
    partial class User999ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Курсовая_работа2.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<byte>("AppointmentCancelButtonVisibility")
                        .HasColumnType("smallint");

                    b.Property<TimeOnly?>("Appointmenthour")
                        .HasColumnType("time without time zone")
                        .HasColumnName("appointmenthour");

                    b.Property<string>("Appointmentstatus")
                        .HasColumnType("character varying")
                        .HasColumnName("appointmentstatus");

                    b.Property<DateOnly>("Appointmenttime")
                        .HasColumnType("date")
                        .HasColumnName("appointmenttime");

                    b.Property<int>("Doctorid")
                        .HasColumnType("integer")
                        .HasColumnName("doctorid");

                    b.Property<int>("Userid")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("appointments_pkey");

                    b.HasIndex("Doctorid");

                    b.HasIndex("Userid");

                    b.ToTable("appointments", (string)null);
                });

            modelBuilder.Entity("Курсовая_работа2.Models.Calldoctorwithoutauth", b =>
                {
                    b.Property<DateOnly>("Apponmentdate")
                        .HasColumnType("date")
                        .HasColumnName("apponmentdate");

                    b.Property<string>("Callreason")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("callreason");

                    b.Property<DateOnly>("Datebirth")
                        .HasColumnType("date")
                        .HasColumnName("datebirth");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("gender");

                    b.Property<string>("Snils")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("snils");

                    b.Property<string>("Useraddress")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("useraddress");

                    b.Property<string>("Useremail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("useremail");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("username");

                    b.Property<string>("Userpatronymicname")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("userpatronymicname");

                    b.Property<string>("Userphone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("userphone");

                    b.Property<string>("Usersurname")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("usersurname");

                    b.ToTable("calldoctorwithoutauth", (string)null);
                });

            modelBuilder.Entity("Курсовая_работа2.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Availabletime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("availabletime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("specialty");

                    b.HasKey("Id")
                        .HasName("doctors_pkey");

                    b.ToTable("doctors", (string)null);
                });

            modelBuilder.Entity("Курсовая_работа2.Models.Medicalrecord", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<int>("Appointmentid")
                        .HasColumnType("integer")
                        .HasColumnName("appointmentid");

                    b.Property<string>("Diagnosis")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("diagnosis");

                    b.Property<int>("Doctorid")
                        .HasColumnType("integer")
                        .HasColumnName("doctorid");

                    b.Property<int>("Userid")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("medicalrecords_pkey");

                    b.HasIndex("Appointmentid");

                    b.HasIndex("Doctorid");

                    b.HasIndex("Userid");

                    b.ToTable("medicalrecords", (string)null);
                });

            modelBuilder.Entity("Курсовая_работа2.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<DateOnly?>("Birthdate")
                        .HasColumnType("date")
                        .HasColumnName("birthdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("Gender")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("gender");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("phonenumber");

                    b.Property<string>("Snils")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("snils");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("username");

                    b.Property<string>("Userpassword")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("userpassword");

                    b.Property<string>("Userpatronymicname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("userpatronymicname");

                    b.Property<string>("Usersurname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("usersurname");

                    b.HasKey("Id")
                        .HasName("users_pkey");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Курсовая_работа2.Models.Appointment", b =>
                {
                    b.HasOne("Курсовая_работа2.Models.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("Doctorid")
                        .IsRequired()
                        .HasConstraintName("appointments_doctorid_fkey");

                    b.HasOne("Курсовая_работа2.Models.User", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("Userid")
                        .IsRequired()
                        .HasConstraintName("appointments_userid_fkey");

                    b.Navigation("Doctor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Курсовая_работа2.Models.Medicalrecord", b =>
                {
                    b.HasOne("Курсовая_работа2.Models.Appointment", "Appointment")
                        .WithMany("Medicalrecords")
                        .HasForeignKey("Appointmentid")
                        .IsRequired()
                        .HasConstraintName("medicalrecords_appointmentid_fkey");

                    b.HasOne("Курсовая_работа2.Models.Doctor", "Doctor")
                        .WithMany("Medicalrecords")
                        .HasForeignKey("Doctorid")
                        .IsRequired()
                        .HasConstraintName("medicalrecords_doctorid_fkey");

                    b.HasOne("Курсовая_работа2.Models.User", "User")
                        .WithMany("Medicalrecords")
                        .HasForeignKey("Userid")
                        .IsRequired()
                        .HasConstraintName("medicalrecords_userid_fkey");

                    b.Navigation("Appointment");

                    b.Navigation("Doctor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Курсовая_работа2.Models.Appointment", b =>
                {
                    b.Navigation("Medicalrecords");
                });

            modelBuilder.Entity("Курсовая_работа2.Models.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Medicalrecords");
                });

            modelBuilder.Entity("Курсовая_работа2.Models.User", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Medicalrecords");
                });
#pragma warning restore 612, 618
        }
    }
}
