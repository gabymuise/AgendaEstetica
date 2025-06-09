using Microsoft.EntityFrameworkCore;
using AgendaEstetica.Model;

namespace AgendaEstetica.Resources
{
    public class AgendaEsteticaContext : DbContext
    {
        // Constructor que recibe opciones del contexto
        public AgendaEsteticaContext(DbContextOptions<AgendaEsteticaContext> options)
            : base(options)
        {
        }

        // DbSets por cada tabla
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<HorarioCita> HorarioCitas { get; set; }
        public DbSet<AgendaCita> AgendaCitas { get; set; }
        public DbSet<AgendaCitaHorarioCita> AgendaCitaHorarioCitas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración clave compuesta para la tabla puente
            modelBuilder.Entity<AgendaCitaHorarioCita>()
                .HasKey(ac => new { ac.IdHorarioCitas, ac.IdAgendaCitas });

            // Relaciones entre entidades
            modelBuilder.Entity<AgendaCitaHorarioCita>()
                .HasOne(ac => ac.HorarioCita)
                .WithMany(h => h.AgendaCitaHorarios)
                .HasForeignKey(ac => ac.IdHorarioCitas);

            modelBuilder.Entity<AgendaCitaHorarioCita>()
                .HasOne(ac => ac.AgendaCita)
                .WithMany(a => a.HorariosCitas)
                .HasForeignKey(ac => ac.IdAgendaCitas);
        }
    }
}
