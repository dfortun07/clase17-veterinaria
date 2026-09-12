using System;
using Microsoft.EntityFrameworkCore;
using clase17david.Models;

namespace clase17david.Data
{
    public class VeterinariaDbContext : DbContext
    {
        public VeterinariaDbContext(DbContextOptions<VeterinariaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Cita> Citas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Mascota>()
                .HasOne(m => m.Propietario)
                .WithMany(p => p.Mascotas)
                .HasForeignKey(m => m.PropietarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Mascota)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.MascotaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Veterinario)
                .WithMany(v => v.Citas)
                .HasForeignKey(c => c.VeterinarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Propietario>().HasData(
                new Propietario { Id = 1, Nombre = "Carlos", Apellidos = "Mendoza Ramos", Telefono = "70123456", Email = "carlos.mendoza@gmail.com", Estado = "Activo" },
                new Propietario { Id = 2, Nombre = "Lucia", Apellidos = "Fernandez Soto", Telefono = "78945612", Email = "lucia.fernandez@hotmail.com", Estado = "Activo" }
            );

            modelBuilder.Entity<Mascota>().HasData(
                new Mascota { Id = 1, PropietarioId = 1, Nombre = "Max", Especie = "Perro", Raza = "Golden Retriever", FechaNacimiento = new DateTime(2022, 5, 10), Estado = "Activo" },
                new Mascota { Id = 2, PropietarioId = 2, Nombre = "Luna", Especie = "Gato", Raza = "Siames", FechaNacimiento = new DateTime(2024, 1, 15), Estado = "Activo" }
            );

            modelBuilder.Entity<Veterinario>().HasData(
                new Veterinario { Id = 1, Nombre = "Roberto", Apellidos = "Gomez Pardo", Especialidad = "Cirugia", Telefono = "71239874", Estado = "Activo" },
                new Veterinario { Id = 2, Nombre = "Mariana", Apellidos = "Vargas Silva", Especialidad = "Medicina General", Telefono = "76543210", Estado = "Activo" }
            );

            modelBuilder.Entity<Cita>().HasData(
                new Cita { Id = 1, MascotaId = 1, VeterinarioId = 1, FechaHora = new DateTime(2026, 9, 15, 10, 0, 0), Motivo = "Revision general", EstadoCita = "Pendiente", Diagnostico = "En evaluacion" },
                new Cita { Id = 2, MascotaId = 2, VeterinarioId = 2, FechaHora = new DateTime(2026, 9, 10, 15, 30, 0), Motivo = "Vacunacion", EstadoCita = "Completada", Diagnostico = "Vacuna aplicada sin complicaciones" }
            );
        }
    }
}
