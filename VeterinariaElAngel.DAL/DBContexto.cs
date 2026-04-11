using System;
using System.Collections.Generic;
using System.Text;
using VeterinariaElAngel.EN;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace VeterinariaElAngel.DAL
{
    internal class DBContexto : DbContext
    {
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Cita> Cita { get; set; }
        public DbSet<Especie> Especie { get; set; }
        public DbSet<Expediente> Expediente { get; set; }
        public DbSet<HistorialExamen> HistorialExamen { get; set; }
        public DbSet<HistorialVacuna> HistorialVacuna { get; set; }
        public DbSet<Mascota> Mascota { get; set; }
        public DbSet<Raza> Raza { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }


    }
}
