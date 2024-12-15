using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace nonk.DAL.Models;

public partial class NonkDbContext : DbContext
{
    public NonkDbContext()
    {
    }

    public NonkDbContext(DbContextOptions<NonkDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Code> Codes { get; set; }

    public virtual DbSet<Investment> Investments { get; set; }

    public virtual DbSet<Mission> Missions { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =REKHANTH\\SQLEXPRESS;Initial Catalog=nonkDB;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Code>(entity =>
        {
            entity.HasKey(e => e.CodeNames).HasName("pk_CodeNames");

            entity.Property(e => e.CodeNames)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Area)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Codewords)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.Codes)
                .HasPrincipalKey(p => p.UserName)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("fk_UserName1");
        });

        modelBuilder.Entity<Investment>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("pk_UserName");

            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Assets)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Entity)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.InvestmentAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Liabilities)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("liabilities");
        });

        modelBuilder.Entity<Mission>(entity =>
        {
            entity.HasKey(e => e.MissionCode).HasName("pk_MissionCode");

            entity.Property(e => e.MissionCode)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(7, 0)");
            entity.Property(e => e.NoOfMissions).HasColumnType("numeric(4, 0)");
            entity.Property(e => e.Status)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.Missions)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("fk_UserName2");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("pk_SkillId");

            entity.Property(e => e.Qualification)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Specialization)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.Skills)
                .HasPrincipalKey(p => p.UserName)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("fk_UserName");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_UserId");

            entity.HasIndex(e => e.UserName, "uq_UserName").IsUnique();

            entity.Property(e => e.EmailId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
