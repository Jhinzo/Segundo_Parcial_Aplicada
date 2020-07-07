using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Segundo_Parcial_Aplicada.Entidades
{
    public class ProyectosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ProyectoId { get; set; }
        public int TareaId { get; set; }
        public string TipoTarea { get; set; }
        public string Requerimiento { get; set; }
        public decimal Tiempo { get; set; }

    }
}