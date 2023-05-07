using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations;

namespace Formularios_BBDD.Models
{
    public class NacionalidadModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Pais { get; set; }
        public List<TrabajadorModel> Trabajadores { get; set; }
        public List<PeliculaModel> Peliculas { get; set; }

    }
}
