using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ControlClientes.Models
{
    public partial class CHPMWebContext : DbContext
    {
        public CHPMWebContext()
        {
        }

        public CHPMWebContext(DbContextOptions<CHPMWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividade> Actividades { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Entregable> Entregables { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Trabajo> Trabajos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=THINKPADT570\\THINKPAD; database=CHPMWeb; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividade>(entity =>
            {
                entity.Property(e => e.CostoPorHora).HasMaxLength(200);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.NombreActividad).HasMaxLength(200);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Actividades_Cliente");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.HorasEstablecidas).HasMaxLength(50);

                entity.Property(e => e.NombreCliente).HasMaxLength(200);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Usuarios");
            });

            modelBuilder.Entity<Entregable>(entity =>
            {
                entity.ToTable("Entregable");

                entity.Property(e => e.CostoTotal).HasMaxLength(500);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.NombreEntregable).HasMaxLength(200);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Rol)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Trabajo>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.NombreTrabajo).HasMaxLength(200);

                entity.HasOne(d => d.IdActividadNavigation)
                    .WithMany(p => p.Trabajos)
                    .HasForeignKey(d => d.IdActividad)
                    .HasConstraintName("FK_Trabajos_Actividades");

                entity.HasOne(d => d.IdEntregableNavigation)
                    .WithMany(p => p.Trabajos)
                    .HasForeignKey(d => d.IdEntregable)
                    .HasConstraintName("FK_Trabajos_Entregable");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_Usuario");

                entity.Property(e => e.Clave).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.NombreUsuario).HasMaxLength(50);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_Usuarios_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
