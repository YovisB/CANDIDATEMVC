using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCCANDIDATE.Models;

public partial class MvccandidateContext : DbContext
{
    public MvccandidateContext()
    {
    }

    public MvccandidateContext(DbContextOptions<MvccandidateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Candidateexperience> Candidateexperiences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=MVCCANDIDATE; Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.Idcandidate).HasName("PK__candidat__8CB0566009EA5281");

            entity.ToTable("candidates");

            entity.HasIndex(e => e.Email, "UQ__candidat__A9D10534AB049ED0").IsUnique();

            entity.Property(e => e.Birthdate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Candidateexperience>(entity =>
        {
            entity.HasKey(e => e.IdCandidateExperience).HasName("PK__candidat__D9A60D65D41C6039");

            entity.ToTable("candidateexperiences");

            entity.Property(e => e.BeginDate).HasColumnType("datetime");
            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Job)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Salary).HasColumnType("numeric(8, 2)");

            entity.HasOne(d => d.IdCandidateNavigation).WithMany(p => p.Candidateexperiences)
                .HasForeignKey(d => d.IdCandidate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__candidate__IdCan__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
