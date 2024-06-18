using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Rusal_228;

public partial class AluminContext : DbContext
{
    public AluminContext()
    {
    }

    public AluminContext(DbContextOptions<AluminContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Batch> Batchs { get; set; }

    public virtual DbSet<DefType> DefTypes { get; set; }

    public virtual DbSet<GeneralStorage> GeneralStorages { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<SizeName> SizeNames { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LUCKYTWICE\\SQLEXPRESS;Database=Alumin;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Batch>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ReportId).HasColumnName("Report_Id");
            entity.Property(e => e.SizeId).HasColumnName("Size_Id");

            entity.HasOne(d => d.Report).WithMany(p => p.Batches)
                .HasForeignKey(d => d.ReportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Batchs_Reports");

            entity.HasOne(d => d.Size).WithMany(p => p.Batches)
                .HasForeignKey(d => d.SizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Batchs_Size_Name");
        });

        modelBuilder.Entity<DefType>(entity =>
        {
            entity.ToTable("Def_Type");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<GeneralStorage>(entity =>
        {
            entity.ToTable("General_Storage");

            entity.Property(e => e.PlacesId).HasColumnName("Places_Id");
            entity.Property(e => e.TypeId).HasColumnName("Type_Id");

            entity.HasOne(d => d.Places).WithMany(p => p.GeneralStorages)
                .HasForeignKey(d => d.PlacesId)
                .HasConstraintName("FK_General_Storage_Places");

            entity.HasOne(d => d.Type).WithMany(p => p.GeneralStorages)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_General_Storage_Materials");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.ProfId).HasColumnName("Prof_Id");
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.Prof).WithMany(p => p.Personals)
                .HasForeignKey(d => d.ProfId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personals_Professions");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.BatchId).HasColumnName("Batch_Id");
            entity.Property(e => e.DefTypeId).HasColumnName("DefType_Id");
            entity.Property(e => e.Mark).HasMaxLength(50);
            entity.Property(e => e.StatusId).HasColumnName("Status_Id");

            entity.HasOne(d => d.Batch).WithMany(p => p.Products)
                .HasForeignKey(d => d.BatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Batch");

            entity.HasOne(d => d.DefType).WithMany(p => p.Products)
                .HasForeignKey(d => d.DefTypeId)
                .HasConstraintName("FK_Products_Def_Type");

            entity.HasOne(d => d.Status).WithMany(p => p.Products)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Status");
        });

        modelBuilder.Entity<Profession>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AddDate)
                .HasColumnType("date")
                .HasColumnName("Add_Date");
            entity.Property(e => e.AddTime)
                .HasPrecision(0)
                .HasColumnName("Add_Time");
            entity.Property(e => e.CryoCount).HasColumnName("Cryo_Count");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.FromId).HasColumnName("From_Id");
            entity.Property(e => e.FromNumber).HasColumnName("From_Number");
            entity.Property(e => e.PersRId).HasColumnName("PersR_Id");
            entity.Property(e => e.PersWId).HasColumnName("PersW_Id");
            entity.Property(e => e.PostNumb).HasColumnName("Post_Numb");
            entity.Property(e => e.PrevId).HasColumnName("Prev_Id");
            entity.Property(e => e.SaltCount).HasColumnName("Salt_Count");
            entity.Property(e => e.Time).HasPrecision(0);
            entity.Property(e => e.ToId).HasColumnName("To_Id");
            entity.Property(e => e.ToNumber).HasColumnName("To_Number");
            entity.Property(e => e.TypeId).HasColumnName("Type_Id");

            entity.HasOne(d => d.From).WithMany(p => p.ReportFroms)
                .HasForeignKey(d => d.FromId)
                .HasConstraintName("FK_Reports_Places");

            entity.HasOne(d => d.PersR).WithMany(p => p.ReportPersRs)
                .HasForeignKey(d => d.PersRId)
                .HasConstraintName("FK_Reports_Personals");

            entity.HasOne(d => d.PersW).WithMany(p => p.ReportPersWs)
                .HasForeignKey(d => d.PersWId)
                .HasConstraintName("FK_Reports_Personals1");

            entity.HasOne(d => d.Prev).WithMany(p => p.InversePrev)
                .HasForeignKey(d => d.PrevId)
                .HasConstraintName("FK_Reports_Reports");

            entity.HasOne(d => d.To).WithMany(p => p.ReportTos)
                .HasForeignKey(d => d.ToId)
                .HasConstraintName("FK_Reports_Places1");

            entity.HasOne(d => d.Type).WithMany(p => p.Reports)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reports_Materials");
        });

        modelBuilder.Entity<SizeName>(entity =>
        {
            entity.ToTable("Size_Name");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
