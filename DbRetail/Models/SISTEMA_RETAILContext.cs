using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbRetail.Models
{
    public partial class SISTEMA_RETAILContext : DbContext
    {
        public SISTEMA_RETAILContext()
        {
        }

        public SISTEMA_RETAILContext(DbContextOptions<SISTEMA_RETAILContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<FacturaHeader> FacturaHeaders { get; set; } = null!;
        public virtual DbSet<FacturaItem> FacturaItems { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;
        public virtual DbSet<Vendedor> Vendedors { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AFEIOT5\\SQLEXPRESS; DataBase=SISTEMA_RETAIL;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("PK__CLIENTE__D87608A6740DAB32");

                entity.ToTable("CLIENTE");

                entity.Property(e => e.Dni)
                    .ValueGeneratedNever()
                    .HasColumnName("dni");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(255)
                    .HasColumnName("correo_electronico");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(255)
                    .HasColumnName("numero_telefono");
            });

            modelBuilder.Entity<FacturaHeader>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__FACTURA___6C08ED5394F6A12E");

                entity.ToTable("FACTURA_HEADER");

                entity.Property(e => e.IdFactura)
                    .ValueGeneratedNever()
                    .HasColumnName("id_factura");

                entity.Property(e => e.FechaEmision)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_emision");

                entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");

                entity.Property(e => e.IdVenta).HasColumnName("id_venta");

                entity.Property(e => e.TotalFactura).HasColumnName("total_factura");
            });

            modelBuilder.Entity<FacturaItem>(entity =>
            {
                entity.HasKey(e => e.IdFacturaItem)
                    .HasName("PK__FACTURA___007EA27C0830A7D3");

                entity.ToTable("FACTURA_ITEM");

                entity.Property(e => e.IdFacturaItem)
                    .ValueGeneratedNever()
                    .HasColumnName("id_factura_item");

                entity.Property(e => e.CantidadVendida).HasColumnName("cantidad_vendida");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.IdVenta).HasColumnName("id_venta");

                entity.Property(e => e.PrecioUnitario).HasColumnName("precio_unitario");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Sku)
                    .HasName("PK__PRODUCTO__DDDF4BE68E7F0314");

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Sku)
                    .ValueGeneratedNever()
                    .HasColumnName("sku");

                entity.Property(e => e.CantidadStock).HasColumnName("cantidad_stock");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio).HasColumnName("precio");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.Cuit)
                    .HasName("PK__SUCURSAL__2CDD9896F453D9AA");

                entity.ToTable("SUCURSAL");

                entity.Property(e => e.Cuit)
                    .ValueGeneratedNever()
                    .HasColumnName("cuit");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(255)
                    .HasColumnName("numero_telefono");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.ToTable("VENDEDOR");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(255)
                    .HasColumnName("correo_electronico");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.NumeroVenta)
                    .HasName("PK__VENTA__44FDAC48DF5976AC");

                entity.ToTable("VENTA");

                entity.Property(e => e.NumeroVenta)
                    .ValueGeneratedNever()
                    .HasColumnName("numeroVenta");

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.FechaVenta)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_venta");

                entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");

                entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

                entity.Property(e => e.TotalVenta).HasColumnName("total_venta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
