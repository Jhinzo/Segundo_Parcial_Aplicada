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
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 1, TipoTarea = "Analisis" });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 2, TipoTarea = "Diseño" });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 3, TipoTarea = "Programacion" });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 4, TipoTarea = "Prueba" });
            //modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 2, TipoTarea = "proyecto 2", Requerimiento = "Dos", Tiempo = 60 });
            //modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 3, TipoTarea = "Prpyectp 3", Requerimiento = "Tres", Tiempo = 60 });
            //modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 4, TipoTarea = "Proyecto 4", Requerimiento = "Cuatro", Tiempo = 60 });
        }
    }
}