using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ClinicaOdontologica.Models
{
    public class OdontologiaDbContext : DbContext
    {
        public OdontologiaDbContext(DbContextOptions<OdontologiaDbContext> options) : base(options)
        {
        }

        public DbSet<Especialidad> Especialidades { get; set; } = null!;
        public DbSet<Odontologo> Odontologos { get; set; } = null!;
        public DbSet<Paciente> Pacientes { get; set; } = null!;
        public DbSet<HistorialMedico> HistorialesMedicos { get; set; } = null!;
        public DbSet<Consultorio> Consultorios { get; set; } = null!;
        public DbSet<Tratamiento> Tratamientos { get; set; } = null!;
        public DbSet<Cita> Citas { get; set; } = null!;
        public DbSet<DetalleCita> DetallesCita { get; set; } = null!;
        public DbSet<Receta> Recetas { get; set; } = null!;
        public DbSet<Factura> Facturas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Restricciones únicas (Indexes Unique)
            modelBuilder.Entity<Odontologo>()
                .HasIndex(o => o.RegistroMedico)
                .IsUnique();

            modelBuilder.Entity<Paciente>()
                .HasIndex(p => p.Dni)
                .IsUnique();

            modelBuilder.Entity<HistorialMedico>()
                .HasIndex(h => h.IdPaciente)
                .IsUnique();

            modelBuilder.Entity<Factura>()
                .HasIndex(f => f.IdCita)
                .IsUnique();

            // Configuración de restricciones de relación
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Citas)
                .HasForeignKey(c => c.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Odontologo)
                .WithMany(o => o.Citas)
                .HasForeignKey(c => c.IdOdontologo)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
