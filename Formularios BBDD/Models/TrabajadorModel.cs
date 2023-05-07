using Formularios_BBDD.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Formularios_BBDD.Models
{
    public class TrabajadorModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public NacionalidadModel Nacionalidad { get; set; }
        public int NacionalidadID { get; set; }
    }
}
