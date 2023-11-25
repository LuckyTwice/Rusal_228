using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Rusal_228;

public partial class MaterialContext : DbContext
{
    public MaterialContext()
    {
    }

    public MaterialContext(DbContextOptions<MaterialContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<MarkaMaterial> MarkaMaterials { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<TypeMaterial> TypeMaterials { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LUCKYTWICE\\SQLEXPRESS;Initial Catalog=Material;Integrated Security=True;Trusted_Connection=true;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<MarkaMaterial>(entity =>
        {
            entity.ToTable("Marka_material");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.MarkaMaterial).HasColumnName("Marka_material");
            entity.Property(e => e.NumberPost).HasColumnName("Number_Post");
            entity.Property(e => e.TypeMaterial).HasColumnName("Type_material");

            entity.HasOne(d => d.CompanyNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.Company)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_Company");

            entity.HasOne(d => d.MarkaMaterialNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.MarkaMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_Marka_material");

            entity.HasOne(d => d.TypeMaterialNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.TypeMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_Type_material");

            entity.HasOne(d => d.UnitNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.Unit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_Unit");
        });

        modelBuilder.Entity<TypeMaterial>(entity =>
        {
            entity.ToTable("Type_material");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.ToTable("Unit");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
