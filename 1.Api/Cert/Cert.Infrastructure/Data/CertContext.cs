using System;
using System.Collections.Generic;
using Cert.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cert.Infrastructure.Data;

public partial class CertContext : DbContext
{
    public CertContext()
    {
    }

    public CertContext(DbContextOptions<CertContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("productos_pkey");

            entity.ToTable("productos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(18, 2)
                .HasColumnName("precio");
            entity.Property(e => e.RowVersion).HasColumnName("row_version");
        });
    }
}
