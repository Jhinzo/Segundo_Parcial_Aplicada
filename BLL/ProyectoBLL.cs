﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Segundo_Parcial_Aplicada.Entidades;
using Segundo_Parcial_Aplicada.DAL;

namespace Segundo_Parcial_Aplicada.BLL
{
    public static class ProyectoBLL
    {    
        public static bool Guardar(Proyectos proyectos)
        {
            bool paso;

            if (!Existe(proyectos.ProyectoId))
                paso = Insertar(proyectos);
            else
                paso = Modificar(proyectos);

            return paso;
        }
        
        public static bool Insertar(Proyectos proyectos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Proyectos.Add(proyectos);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        
        public static bool Modificar(Proyectos proyectos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                
                contexto.Database.ExecuteSqlRaw($"Delete From ProyectosDetalle Where ProyectoId={proyectos.ProyectoId}");

                foreach (var item in proyectos.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(proyectos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var proyectos = contexto.Proyectos.Find(id);
                if (proyectos != null)
                {
                    contexto.Proyectos.Remove(proyectos);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
       
        public static List<Proyectos> GetList(Expression<Func<Proyectos, bool>> criterio)
        {
            List<Proyectos> lista = new List<Proyectos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Proyectos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
       
        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Proyectos.Any(p => p.ProyectoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
        
        public static Proyectos Buscar(int id)
        {
            Proyectos proyectos = new Proyectos();
            Contexto contexto = new Contexto();

            try
            {
                proyectos = contexto.Proyectos
                    .Where(p => p.ProyectoId == id).Include(x=>x.Detalle)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return proyectos;
        }
    }
}