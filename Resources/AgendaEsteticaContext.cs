using AgendaEstetica.Model;
using Microsoft.EntityFrameworkCore;
using System;

public class AgendaEsteticaContext : DbContext
{
    public DbSet<Empleados> Empleados { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Servicios> Servicios { get; set; }
    public DbSet<HorarioCita> HorarioCitas { get; set; }
    public DbSet<AgendaCitas> AgendaCitas { get; set; }
    public DbSet<AgendaCitaHorario> AgendaCitaHorarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=GABRIELMUISE\SQLEXPRESS;Database=agendaEstetica;Trusted_Connection=True;TrustServerCertificate=True;");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-10BAS3U\SQLEXPRESS;Database=agendaEstetica;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de Empleados
        modelBuilder.Entity<Empleados>(entity =>
        {
            entity.ToTable("Empleados");
            entity.HasKey(e => e.IdEmpleado);
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Nombre).HasColumnName("nombre").IsRequired();
            entity.Property(e => e.Especialidad).HasColumnName("especialidad").IsRequired();
            entity.Property(e => e.Telefono).HasColumnName("telefono").IsRequired();
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.DeletedAt).HasColumnName("deletedAt");
        });

        // Configuración de Clientes
        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.ToTable("Clientes");
            entity.HasKey(e => e.IdCliente);
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.NombreApellido).HasColumnName("nombreApellido").IsRequired();
            entity.Property(e => e.Telefono).HasColumnName("telefono").IsRequired();
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.DeletedAt).HasColumnName("deletedAt");
        });

        // Configuración de Servicios
        modelBuilder.Entity<Servicios>(entity =>
        {
            entity.ToTable("Servicios");
            entity.HasKey(e => e.IdServicios);
            entity.Property(e => e.IdServicios).HasColumnName("idServicios");
            entity.Property(e => e.Nombre).HasColumnName("nombre").IsRequired();
            entity.Property(e => e.DuracionEstimada).HasColumnName("duracionEstimada").IsRequired();
            entity.Property(e => e.Precio).HasColumnName("precio").HasColumnType("decimal(10,2)").IsRequired();
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.DeletedAt).HasColumnName("deletedAt");
        });

        // Configuración de HorarioCita
        modelBuilder.Entity<HorarioCita>(entity =>
        {
            entity.ToTable("HorarioCita");
            entity.HasKey(e => e.Idhorarios);
            entity.Property(e => e.Idhorarios).HasColumnName("idhorarios");
            entity.Property(e => e.Dia).HasColumnName("dia").IsRequired();
            entity.Property(e => e.Fecha).HasColumnName("fecha").IsRequired();
            entity.Property(e => e.Hora).HasColumnName("Hora").IsRequired();
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado").IsRequired();
            entity.Property(e => e.Disponible).HasColumnName("disponible").HasDefaultValue(true);
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.DeletedAt).HasColumnName("deletedAt");

            entity.HasOne(h => h.Empleado)
                  .WithMany(e => e.HorarioCitas)
                  .HasForeignKey(h => h.IdEmpleado)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de AgendaCita
        modelBuilder.Entity<AgendaCitas>(entity =>
        {
            entity.ToTable("AgendaCitas");
            entity.HasKey(e => e.IdAgendaCitas);
            entity.Property(e => e.IdAgendaCitas).HasColumnName("idAgendaCitas");
            entity.Property(e => e.PrecioFinal).HasColumnName("precioFinal").HasColumnType("decimal(10,2)").IsRequired();
            entity.Property(e => e.Pagado).HasColumnName("pagado").HasDefaultValue(false);
            entity.Property(e => e.Finalizado).HasColumnName("finalizado").HasDefaultValue(false);
            entity.Property(e => e.IdCliente).HasColumnName("idCliente").IsRequired();
            entity.Property(e => e.IdServicios).HasColumnName("idServicios").IsRequired();
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.DeletedAt).HasColumnName("deletedAt");

            entity.HasOne(a => a.Cliente)
                  .WithMany(c => c.AgendaCitas)
                  .HasForeignKey(a => a.IdCliente)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.Servicio)
                  .WithMany(s => s.AgendaCitas)
                  .HasForeignKey(a => a.IdServicios)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de la tabla puente AgendaCitas_has_HorarioCitas
        modelBuilder.Entity<AgendaCitaHorario>(entity =>
        {
            entity.ToTable("AgendaCitas_has_HorarioCitas");
            entity.HasKey(e => new { e.IdHorarioCitas, e.IdAgendaCitas });
            entity.Property(e => e.IdHorarioCitas).HasColumnName("idHorarioCitas");
            entity.Property(e => e.IdAgendaCitas).HasColumnName("idAgendaCitas");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasDefaultValueSql("GETDATE()");

            entity.HasOne(ah => ah.HorarioCita)
                  .WithMany(h => h.AgendaCitaHorarios)
                  .HasForeignKey(ah => ah.IdHorarioCitas)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ah => ah.AgendaCita)
                  .WithMany(a => a.AgendaCitaHorarios)
                  .HasForeignKey(ah => ah.IdAgendaCitas)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Filtros para entidades eliminadas
        modelBuilder.Entity<Empleados>().HasQueryFilter(e => e.DeletedAt == null);
        modelBuilder.Entity<Clientes>().HasQueryFilter(c => c.DeletedAt == null);
        modelBuilder.Entity<Servicios>().HasQueryFilter(s => s.DeletedAt == null);
        modelBuilder.Entity<HorarioCita>().HasQueryFilter(h => h.DeletedAt == null);
        modelBuilder.Entity<AgendaCitas>().HasQueryFilter(a => a.DeletedAt == null);
    }
}