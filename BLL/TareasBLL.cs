using Segundo_Parcial_Aplicada.DAL;
using Segundo_Parcial_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segundo_Parcial_Aplicada.BLL
{
    public class TareasBLL
    {
        public static List<Tareas> GetList()
        {
            List<Tareas> tareas = new List<Tareas>();
            Contexto contexto = new Contexto();

            try
            {
                tareas = contexto.Tareas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tareas;
        }
    }
}