using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations;

namespace Formularios_BBDD.Models
{
    public class NacionalidadModelo
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Pais { get; set; }
        public List<TrabajadorModelo> Trabajadores { get; set; }
        public List<PeliculaModelo> Peliculas { get; set; }

    }
}
