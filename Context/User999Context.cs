using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Курсовая_работа2.Models;

namespace Курсовая_работа2.Context;

public partial class User999Context : DbContext
{
    public User999Context()
    {
    }

    public User999Context(DbContextOptions<User999Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Calldoctorwithoutauth> Calldoctorwithoutauths { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Medicalrecord> Medicalrecords { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=193.176.78.35;port=5433;Database=user999;Username=user999;password=bqmV");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("appointments_pkey");

            entity.ToTable("appointments");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Appointmenthour).HasColumnName("appointmenthour");
            entity.Property(e => e.Appointmentstatus)
                .HasColumnType("character varying")
                .HasColumnName("appointmentstatus");
            entity.Property(e => e.Appointmenttime).HasColumnName("appointmenttime");
            entity.Property(e => e.Doctorid).HasColumnName("doctorid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Doctorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointments_doctorid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointments_userid_fkey");
        });

        modelBuilder.Entity<Calldoctorwithoutauth>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("calldoctorwithoutauth");

            entity.Property(e => e.Apponmentdate).HasColumnName("apponmentdate");
            entity.Property(e => e.Callreason)
                .HasColumnType("character varying")
                .HasColumnName("callreason");
            entity.Property(e => e.Datebirth).HasColumnName("datebirth");
            entity.Property(e => e.Gender)
                .HasMaxLength(15)
                .HasColumnName("gender");
            entity.Property(e => e.Snils)
                .HasMaxLength(30)
                .HasColumnName("snils");
            entity.Property(e => e.Useraddress)
                .HasColumnType("character varying")
                .HasColumnName("useraddress");
            entity.Property(e => e.Useremail)
                .HasMaxLength(100)
                .HasColumnName("useremail");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
            entity.Property(e => e.Userpatronymicname)
                .HasColumnType("character varying")
                .HasColumnName("userpatronymicname");
            entity.Property(e => e.Userphone)
                .HasMaxLength(100)
                .HasColumnName("userphone");
            entity.Property(e => e.Usersurname)
                .HasColumnType("character varying")
                .HasColumnName("usersurname");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doctors_pkey");

            entity.ToTable("doctors");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Availabletime)
                .HasMaxLength(100)
                .HasColumnName("availabletime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Specialty)
                .HasMaxLength(100)
                .HasColumnName("specialty");
        });

        modelBuilder.Entity<Medicalrecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("medicalrecords_pkey");

            entity.ToTable("medicalrecords");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Appointmentid).HasColumnName("appointmentid");
            entity.Property(e => e.Diagnosis)
                .HasMaxLength(500)
                .HasColumnName("diagnosis");
            entity.Property(e => e.Doctorid).HasColumnName("doctorid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Appointment).WithMany(p => p.Medicalrecords)
                .HasForeignKey(d => d.Appointmentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicalrecords_appointmentid_fkey");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Medicalrecords)
                .HasForeignKey(d => d.Doctorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicalrecords_doctorid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Medicalrecords)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicalrecords_userid_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(100)
                .HasColumnName("gender");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Snils)
                .HasMaxLength(20)
                .HasColumnName("snils");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
            entity.Property(e => e.Userpassword)
                .HasMaxLength(100)
                .HasColumnName("userpassword");
            entity.Property(e => e.Userpatronymicname)
                .HasMaxLength(100)
                .HasColumnName("userpatronymicname");
            entity.Property(e => e.Usersurname)
                .HasMaxLength(100)
                .HasColumnName("usersurname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
