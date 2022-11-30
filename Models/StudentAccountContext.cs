using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace labb04_KPZ.Models;

public partial class StudentAccountContext : DbContext
{
    public StudentAccountContext()
    {
    }

    public StudentAccountContext(DbContextOptions<StudentAccountContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB; Database=StudentAccount;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.Loggin)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.ToTable("Achievement");

            entity.Property(e => e.Describtion)
                .HasMaxLength(150)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsFixedLength();
            entity.Property(e => e.StudentId).HasColumnName("Student_Id");

            entity.HasOne(d => d.Student).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Achievement_Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.HasIndex(e => e.AccountId, "IX_Student").IsUnique();

            entity.Property(e => e.AccountId).HasColumnName("Account_Id");
            entity.Property(e => e.Group)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Institute)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Surname)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.HasOne(d => d.Account).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.AccountId)
                .HasConstraintName("FK_Student_Account1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
