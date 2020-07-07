using Microsoft.EntityFrameworkCore;
using Segundo_Parcial_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Segundo_Parcial_Aplicada.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<Tareas> Tareas { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\ProyectoTareas_DB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 1, TipoTarea = "proyecto 1", Requerimiento = "1", Tiempo = 60 });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 2, TipoTarea = "proyecto 2", Requerimiento = "2", Tiempo = 60 });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 3, TipoTarea = "Prpyectp 3", Requerimiento = "3", Tiempo = 60 });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 4, TipoTarea = "Proyecto 4", Requerimiento = "4", Tiempo = 60 });
        }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}